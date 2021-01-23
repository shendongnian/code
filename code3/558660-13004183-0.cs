    public static object InstObject(Assembly ass, string className)
    {
    	AppDomain dom = null;
    	try
    	{
    		Evidence evidence = new Evidence(AppDomain.CurrentDomain.Evidence);
    
    		string fullPath = ass.CodeBase.Replace("file:///", "").Replace("/", "\\");
    		AssemblyName assemblyName = new AssemblyName();
    		assemblyName.CodeBase = fullPath;
    		dom = AppDomain.CreateDomain("TestDomain", evidence, 
                     AppDomain.CurrentDomain.BaseDirectory, 
                     System.IO.Path.GetFullPath(fullPath), true);
    
    		Assembly assembly = dom.Load(assemblyName);
    		Type type = assembly.GetType(className);
    
    		object obj = Activator.CreateInstance(type);
    
    		return obj;
    	}
    	finally
    	{
    		if (dom != null) AppDomain.Unload(dom);
    	}
    }
