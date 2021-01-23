    protected void Application_Start()
        {
            try
            {
               .
               .
               .
                SetTimer();
            }
            catch (Exception ex)
            {
                ...
            }
        }
       
        private static void SetTimer()
        {
            DateTime tomorow = DateTime.Now.AddDays(1);
            DateTime midnight = new DateTime(tomorow.Year, tomorow.Month, tomorow.Day, 0, 0, 0);
            TimeSpan d = midnight - DateTime.Now;
            sTimer.Enabled = true;
            sTimer.Interval = d.TotalMilliseconds;
            sTimer.Elapsed += new System.Timers.ElapsedEventHandler(sTimer_Elapsed);
            sTimer.Start();
        }
       
        static void sTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sTimer.Interval = TimeSpan.FromHours(24).TotalMilliseconds;
            db = new CompanyContext();
            
            //some func
            sendInOutUsers();            
            AlartUsers();
        }
       
