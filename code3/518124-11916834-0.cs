    var timer = new Timer(30000); // Interval of 30 seconds
    timer.Elapsed = OnTimedEvent;
    timer.Start();
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Update logic here.
    }
