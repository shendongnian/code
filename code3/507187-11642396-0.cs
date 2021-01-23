    //Define the timer 
    private System.Timers.Timer buttonTimer;
    // Initialize the timer with a five second interval.
    buttonTimer= new System.Timers.Timer(5000);
    // Hook up the Elapsed event for the timer.
    buttonTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    //Start the timer
    buttonTimer.Start();
    // Enable the button in timer elapsed event handler
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        button1.Enabled = true;
    }
