        // Create a 30 min timer 
        timer = new System.Timers.Timer(1800000);
        // Hook up the Elapsed event for the timer.
        timer.Elapsed += OnTimedEvent;
        timer.Enabled = true;
    ...
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // do stuff
    }
