    using System;
    using System.Timers;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var timer1 = new System.Timers.Timer { Interval = 30000, Enabled = true };
                var timer2 = new System.Timers.Timer { Interval = 20000, Enabled = true };
                var timer3 = new System.Timers.Timer { Interval = 10000, Enabled = true };
                var timer4 = new System.Timers.Timer { Interval = 5000, Enabled = true };
    
                timer1.Elapsed += timer1_Elapsed;
                timer2.Elapsed += timer2_Elapsed;
                timer3.Elapsed += timer3_Elapsed;
                timer4.Elapsed += timer4_Elapsed;
            }
    
            void timer4_Elapsed(object sender, ElapsedEventArgs e)
            {
                //do work here
            }
    
            void timer3_Elapsed(object sender, ElapsedEventArgs e)
            {
                //do work here
            }
    
            void timer2_Elapsed(object sender, ElapsedEventArgs e)
            {
                //do work here
            }
    
            void timer1_Elapsed(object sender, ElapsedEventArgs e)
            {
                //do work here
            }
        }
    }
