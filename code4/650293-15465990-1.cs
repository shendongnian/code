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
            int amount;
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                amount = 5;
                amount = amount + textBox1.Text.Length;            
                label1.Text = amount.ToString();
            }
        }
    }
