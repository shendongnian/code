      protected override void OnStart(string[] args)
        {
           
            aTimer = new System.Timers.Timer();
            string starttime = "01.25";
            //start time is 01.25 means 01:15 AM
            double mins = Convert.ToDouble(starttime);
            DateTime t = DateTime.Now.Date.AddHours(mins);
            TimeSpan ts = new TimeSpan();
            // ts = t - System.DateTime.Now;
            ts = t.AddDays(1) - System.DateTime.Now;
            if (ts.TotalMilliseconds < 0)
            {
                ts = t.AddDays(1) - System.DateTime.Now;
                // ts = t - System.DateTime.Now;
            }
            _timeinterval = ts.TotalMilliseconds;
           // _timeinterval now set to 1:15 am (time from now to 1:15AM)
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = _timeinterval;
            aTimer.Enabled = true;
           }
            private static void OnTimedEvent(object source, ElapsedEventArgs e)
             {
           
               // operation to perform
               aTimer.Interval = 86400000; // now interval sets to 24 hrs
            
        }
