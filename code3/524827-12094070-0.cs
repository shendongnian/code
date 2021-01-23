    string[] ignoreAssembyVersions = new string[] { "log4net" };
    AppDomain.CurrentDomain.AssemblyResolve += (_, assembly) =>
    {
    	//ignore the vesion number and return any version that has been loaded
    	var name = new AssemblyName(assembly.Name);
    	var shortName = name.Name; // retrieve short name
    	if (ignoreAssembyVersions.Contains(shortName)) // compare against list of assemblies we ignore revisions for
    	{
    		// check if this assembly is already loaded under a different version #
    		Assembly[] allAss = AppDomain.CurrentDomain.GetAssemblies();
    		List<Assembly> list = new List<Assembly>(allAss);
    		var loadedAssembly = list.Find(ass => new AssemblyName(ass.FullName).Name == shortName); // check if we have any version loaded yet
    		if (loadedAssembly != null)
    			return loadedAssembly;
    		else // assembly has not yet been loaded in this domain
    		{   // probe for assembly by name
    			Assembly probedAssembly = Assembly.LoadFrom(string.Format("{0}.dll", shortName)); // probe for any match on assembly.dll 
    			return probedAssembly;
    		}
    	}
    	return null; // ignore binding failure -> pass up the stack
    };
