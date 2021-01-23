       System.Timers.Timer timer = new System.Timers.Timer();
    
            protected override void OnStart(string[] args)
            {
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
                timer.Interval = AppSettings.PeriodOfQuering;
            }
    
            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                DoJob();
            }
