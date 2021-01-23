    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                timer1.Tick += timer1_Tick;
                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer1.Start();
            }
    
            Timer timer1 = new Timer();
    
            void timer1_Tick(object sender, EventArgs e)
            {
                TimeSpan TimeRemaining = VoteTime - DateTime.Now;
                label1.Text = TimeRemaining.Hours + " : " + TimeRemaining.Minutes + " : " + TimeRemaining.Seconds;
            }
          
