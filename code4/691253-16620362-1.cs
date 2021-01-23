    using System;
    using System.Windows.Forms;
    
    namespace StackOverflowCountDown
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                textBox1.Text = TimeSpan.FromMinutes(30).ToString();
            }
    
            private void Form1_Load(object sender, EventArgs e) { }
    
            private void textBox1_TextChanged(object sender, EventArgs e) { }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var startTime = DateTime.Now;
    
                var timer = new Timer() { Interval = 1000 };
    
                timer.Tick += (obj, args) =>    
                    textBox1.Text =
                        (TimeSpan.FromMinutes(30) - (DateTime.Now - startTime))
                        .ToString("hh\\:mm\\:ss");
                
                timer.Enabled = true;
            }
        }
    }
