     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                stopWatch.Start();
                tm.Interval = 1000;
                tm.Enabled = true; 
                tm.Tick += new EventHandler(tm_Tick);
                tm.Start();
            }
    
            void tm_Tick(object sender, EventArgs e)
            {
                double sec = stopWatch.ElapsedMilliseconds / 1000;
                double min = sec / 60;
                double hour = min / 60;
                if (hour == 9.00D)
                {
                    stopWatch.Stop();
                    MessageBox.Show("passed: " + hour.ToString("0.00"));
                }
            }
         }
