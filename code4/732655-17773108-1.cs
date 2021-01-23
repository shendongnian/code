    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    
        public partial class Form1 : Form
        {
            int timerInterval, curWidth, curHeight, incWidth, incHeight, maxWidth, maxHeight;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                curWidth = this.Location.X + this.Width;
                curHeight = this.Location.Y + this.Height;
                incWidth = 100;
                incHeight = 20;
                maxWidth = 2000;
                maxHeight = 1500;
                timerInterval = 100;
                timer1.Enabled = false;
                timer1.Interval = timerInterval;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                curWidth = curWidth + incWidth;
                curHeight = curHeight + incHeight;
                if (curWidth >= maxWidth)
                {
                    curWidth = maxWidth;
                }
                if (curHeight >= maxHeight)
                {
                    curHeight = maxHeight;
                }
    
                this.Width = curWidth;
                this.Height = curHeight;
    
                if (this.Width == maxWidth && this.Height == maxHeight)
                {
                    timer1.Stop();
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                  timer1.Enabled = !timer1.Enabled;
            }
        }
    }
