    public static void Main()
    {
    	AppDomain currentDomain = AppDomain.CurrentDomain;
    
    	currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    }
    
    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
    	if ( e.Name.Contains("SqlWmiManagement"))
    	{
    		// assembly not found
    	}
    	
    	return null;
    }
