    System.Timers.Timer timer = new System.Timers.Timer();
    var i = 0;
    var times = 10;
    public SetupTimer()
    {
        timer.Interval = 500;
        timer.Elapsed += OnTimerElapsed;
        timer.Start();
    }
    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // Logic
        if (i > times)
        {
           timer.Stop();
        }
    }
