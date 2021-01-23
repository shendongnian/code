    void Application_Start(object sender, EventArgs e)
    {
    	// Create a new Timer with Interval set to 300 seconds(5 Minutes).
    	System.Timers.Timer aTimer = new System.Timers.Timer(5 * 60 * 1000);
    	aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
    	aTimer.AutoReset = true;
    	aTimer.Enabled = true;
    	aTimer.Start();
    }
    private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
    {
    //Send Email;
    }
