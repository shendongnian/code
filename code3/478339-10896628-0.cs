    private static System.Timers.Timer aTimer;
    private static System.DateTime _last;
    
    public static void Main()
    {
    	aTimer = new System.Timers.Timer(10000);
    
    	aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
    	aTimer.Interval = 1000;
    	aTimer.Enabled = true;
    
    	Console.WriteLine("Press the Enter key to exit the program.");
    	Console.ReadLine();
    }
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
    	DateTime time = 
            new DateTime( 1,1,1, DateTime.Now.Hours, DateTime.Now.Minute );
    
    	if( time.Minute==0 ||time.Minute==15 || time.Minute==30 || time.Minute==45 )
    	{
    		// Avoid multiple notifications for the same quarter.
    		if ( _last==DateTime.MinValue || _last!=time )
    		{
    			_last = time;
    
    			// Do further processing.
    			doProcessing();
    		}
    	}
    }
