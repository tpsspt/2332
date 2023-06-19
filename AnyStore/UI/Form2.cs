using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnyStore.UI;

namespace AnyStore
{
    public partial class Form2 : Form
    {
        private string captcha;
        private int attemptsLeft = 3;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == captcha)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                this.Hide();
            }
            else
            {
                attemptsLeft--;
                if (attemptsLeft <= 0)
                {
                    MessageBox.Show("Вы потратили все попытки. Приложение будет закрыто.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверная капча. Попробуйте еще раз. У вас осталось " + attemptsLeft + " попытка(и).");
                    GenerateCaptcha();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenerateCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            captcha = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            Bitmap bitmap = new Bitmap(200, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Font font = new Font("Arial", 40, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            graphics.DrawString(captcha, Font, brush, 10, 10);

            for (int i = 0; i < 50; i++)
            {
                int x1 = random.Next(bitmap.Width);
                int y1 = random.Next(bitmap.Height);
                int x2 = random.Next(bitmap.Width);
                int y2 = random.Next(bitmap.Height);
                graphics.DrawLine(Pens.Gray, x1, y1, x2, y2);
            }
            pictureBox1.Image = bitmap;
        }
    }
}
