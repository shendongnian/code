    System.Timers.Timer aTimer = new System.Timers.Timer(10000);
    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    // Set the Interval to 60 seconds (60000 milliseconds).
    aTimer.Interval = 60000;
    //for enabling for disabling the timer.
    aTimer.Enabled = false;
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
     //disable the timer
     aTimer.Enabled = false;
     Method2();
    }
    public void Method1()
    {
     //some code
     aTimer.Enabled = true;
    }
    public void Method2()
    {
    }
