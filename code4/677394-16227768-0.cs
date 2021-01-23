    public static MainForm _mainForm;
    { 
      //Add this in your main initialization   
      AppDomain.CurrentDomain.AssemblyResolve+=new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    	if (args.Name.Contains("FullNameSpace.MouseKeyboardActivityMonitor"))
    	{
    		return Assembly.Load(Properties.Resources.MouseKeyboardActivityMonitor);
    	}
    
    	if (args.Name.Contains("FullNameSpace.MouseKeyboardActivityMonitor"))
    	{
    		return Assembly.Load(Properties.Resources.WindowsFormsAero);
    	}
    
    	return null;
    }
        
