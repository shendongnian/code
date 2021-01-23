    System.Timers.Timer aTimer;
    {
        aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 60000;
        aTimer.Enabled = true;
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
    }
