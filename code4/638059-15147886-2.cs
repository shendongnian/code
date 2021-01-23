    public static void Main()
    {
        // Note: AssemblyResolve occurs when the resolution of an assembly fails.
    	AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    }
    
    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
    	if ( args.Name.Contains("SqlWmiManagement"))
    	{
    		// assembly not found
    	}
    	
    	return null;
    }
