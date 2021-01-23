    public static System.Timers.Timer aTimer;
    ...
    aTimer = new System.Timers.Timer(50000);
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    aTimer.AutoReset = false; //This should be true if you want it actually looping
    aTimer.Enabled = true;
