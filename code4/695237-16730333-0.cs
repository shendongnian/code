    using System;
    using System.Windows.Forms;
    namespace StackOverflowWin
    {
        public partial class Form1 : Form
        {
            public static TextBox textBox;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                textBox = textBox1;
                TestClass.StaticMethod();
            }
        }
        public static class TestClass
        {
            public static void StaticMethod()
            {
                Form1.textBox.Text = "works";
            }
        }
    }
