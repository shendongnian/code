        DateTime dStartTime = DateTime.Now;
        TimeSpan span = new TimeSpan(0, 0, 0);
        int timeout = 30; //30 seconds        
        private void timer1_Tick(Object myObject, EventArgs myEventArgs)
        {
            while (span.Seconds < timeout)
            {
                Process[] processList = Process.GetProcessesByName("<YourProcess.exe>");
                if (processList.Length == 0)
                {
                    //process completed
                    timer1.Stop();
                    break;
                }
                span = DateTime.Now.Subtract(dStartTime);
            }
            if (span.Seconds > timeout)
            {
                Process[] processList = Process.GetProcessesByName("<YourProcess.exe>");
                //Give it one last chance to complete
                if (processList.Length != 0)
                {
                    //process not completed
                    foreach (Process p in processList)
                    {
                        p.Kill();
                    }
                }
                timer1.Stop();
            }
        }
