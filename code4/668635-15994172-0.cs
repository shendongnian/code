    private static bool IsOn = true; //default to true (is on)
    static void Main(string[] args)
    {
        Timer aTimer = new Timer();
        
        // Hook up the Elapsed event for the timer.
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);        
        // Set the Interval to 2 seconds 
        aTimer.Interval = 2000;
        aTimer.Enabled = true;    
        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();
    }
    // Specify what you want to happen when the Elapsed event is  
    // raised. 
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        IsOn = !IsOn;
        Console.WriteLine("The status is {0} {1}", IsOn.ToString(), e.SignalTime);
    }
    
