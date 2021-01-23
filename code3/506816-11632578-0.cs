    System.Timers.Timer aTimer;
    aTimer = new System.Timers.Timer();
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    aTimer.Interval = 2000;
    aTimer.Enabled = true;
    
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //your code
    }
