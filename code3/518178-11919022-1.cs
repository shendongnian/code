    private System.Timers.Timer _timer;    
    
    private void SetTimer()
    {
        DateTime currentTime = DateTime.Now;
        int intervalToElapse = 0;
        DateTime scheduleTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10,0,0);
                
        if (currentTime <= scheduleTime)
            intervalToElapse = (int)scheduleTime.Subtract(currentTime).TotalSeconds;
        else
            intervalToElapse = (int)scheduleTime.AddDays(1).Subtract(currentTime).TotalSeconds;
    
        _timer = new System.Timers.Timer(intervalToElapse);
    
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
        _timer.Start();
    }
    
    void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
           //do your work
           _timer.Interval = (24 * 60 * 60 * 1000);
    }
