    private void SetTimer(DateTime remindLater)
            {
                timer = new System.Timers.Timer();
                TimeSpan timeSpan = remindLater - DateTime.Now;
                timer.Interval = (int) timeSpan.TotalMilliseconds;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
    
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                timer.Stop();
                AutoUpdater.Start(appCast, remindLaterAt, remindLaterFormat);
            }
