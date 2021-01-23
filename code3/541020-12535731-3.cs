    public static void Main()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval=5000;
        aTimer.Enabled=true;
 
        Console.WriteLine("Press \'q\' to quit the sample.");
        while(Console.Read()!='q');
    }
 
     // Specify what you want to happen when the Elapsed event is raised.
     private static void OnTimedEvent(object source, ElapsedEventArgs e)
     {
         Console.WriteLine("Hello World!");
     }
