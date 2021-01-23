        bool started = false;
        private void wichProcessIsrun()
        {
            Process[] pname = Process.GetProcessesByName("BFBC2Game");
            if (pname.Length == 0 && started)
            {
                Logger.Write("Battlefield Bad Company 2 Ended");
                started = false;
            }
            else if(pname.Length != 0 && !started)
            {
                Logger.Write("Battlefield Bad Company 2 Started");
                backgroundWorker1.RunWorkerAsync();
                started = true;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            wichProcessIsrun();
        }
