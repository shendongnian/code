    public void CreateTimer() 
    {
        var timer = new System.Timers.Timer(1000); // fire every 1 second
        timer.Elapsed += HandleTimerElapsed;
    }
    
    public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // do whatever it is that you need to do on a timer
    }
