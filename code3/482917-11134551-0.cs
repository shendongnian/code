    var trace = new StackTrace();
    var assemblies = new List<Assembly>();
    var frames = trace.GetFrames();
    
    if(frames == null)
    {
    	throw new Exception("Couldn't get the stack trace");
    }
    
    foreach(var frame in frames)
    {
    	var method = frame.GetMethod();
    	var declaringType = method.DeclaringType;
    
    	if(declaringType == null)
    	{
    		continue;
    	}
    
    	var assembly = declaringType.Assembly;
    	var lastAssembly = assemblies.LastOrDefault();
    	
    	if(assembly != lastAssembly)
    	{
    		assemblies.Add(assembly);
    	}
    }
    
    foreach(var assembly in assemblies)
    {
    	Debug.WriteLine(assembly.ManifestModule.Name);
    }
