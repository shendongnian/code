    protected void AutoMapperConfig()
    {
    	const string mappingNamespace = "MyProject.Web.Core.Mappings";
    
    	//There are ways to accomplish this same task more efficiently.
        var q = (from t in Assembly.LoadFrom("YourAssemblyName.dll").GetExportedTypes()
                 where t.IsClass && t.Namespace == mappingNamespace
                 select t).ToList();
    	//Assuming all the types in this namespace have defined a
    	//default constructor. Otherwise, this iterative call will
    	//eventually throw a TypeLoadException (I believe) because
    	//the arguments for any of the possible constructors for the
    	//type were not provided in the call to Activator.CreateInstance(t) 
    	q.ForEach(t => Activator.CreateInstance(t));
    }
