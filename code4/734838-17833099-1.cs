    public class Monitoring
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    
        public Monitoring()
        {
            timer1.Interval = 1000; //Period of Tick
            timer1.Tick += timer1_Tick;
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckBatteryStatus(); 
        }
        private void CheckBatteryStatus()
        {
            PowerStatus pw = SystemInformation.PowerStatus;
    
            if (pw.BatteryLifeRemaining >= 75)
            {
                //Do stuff here
            }
        }
    }
