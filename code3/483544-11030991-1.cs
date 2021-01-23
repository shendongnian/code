    private static System.Timers.Timer aTimer = new System.Timers.Timer();
    // This method will be called at the interval specified in EnableTimer
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        aTimer.Enabled = false;  // stop timer
        IpCheck();
        aTimer.Enabled = true;   // restart timer so this method will be called in X secs
    }
    private static void EnableTimer()
    {
        // Set the Interval to x seconds.
        aTimer.Interval = 10000;
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Enabled=true;  // actually starts timer
    }
