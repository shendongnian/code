    aTimer = new System.Timers.Timer(10000);
    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    aTimer.Interval = 2000;
    aTimer.Enabled = true;
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        btnSave_Click(btnSave, EventArgs.Empty);
    }
    
