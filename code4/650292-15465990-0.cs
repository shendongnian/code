    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }        
            int amount = 5;
            int length = 0;
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                if (textBox1.Text.Length > length)
                {
                    amount++;
                }
                else
                {
                    amount--;
                }
                length = textBox1.Text.Length;
                label1.Text = amount.ToString();
            }
        }
    }
