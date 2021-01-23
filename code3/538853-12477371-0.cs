    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                button2.Visible = false;
    
                Width = 100;
                Height = 100;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Width = 200;
                Height = 200;
                button2.Visible = true;
            }
        }
    }
