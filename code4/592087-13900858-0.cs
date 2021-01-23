    Execute(...)
    {
    	if(System.Diagnostics.Trace.Listeners
    		.Count(l => typeof(l) == MyCustomTraceListener) == 0)
    	{
    		System.Diagnostics.Trace.Listeners.Add(new MyCustomTraceListener());
    	}
    
    	DoWork();
    }
    
    DoWork()
    {	
    	System.Diagnostics.Trace.WriteLine("I'm doing work!");
    }
