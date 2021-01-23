    static void Main( string[] args )
    {
        log4net.Config.XmlConfigurator.Configure();
        log4net.ThreadContext.Properties[ "myContext" ] = "Logging from Main";
        Log.Info( "this is an info message" );
        Console.ReadLine();
    }
    
	
