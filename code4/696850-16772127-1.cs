    protected override void OnStart(string[] args)
    {
        aTimer = new System.Timers.Timer(10000);
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 60000;
        aTimer.Enabled = true;
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        aTimer.Enabled = false;
        // Put file processing code here.
        aTimer.Enabled = true;
    }
