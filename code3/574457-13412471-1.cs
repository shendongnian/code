    protected void AutoMapperConfig()
    {
    	const string mappingNamespace = "MyProject.Web.Core.Mappings";
    
    	//There are ways to accomplish this same task more efficiently.
    	var q = from t in Assembly.LoadFrom("YourAssemblyName.dll").GetExportedTypes()
    		    where t.IsClass && t.Namespace == mappingNamespace
    		    select t;
    	//Assuming all the types in this namespace have defined a default constructor.
    	q.ForEach(t => Activator.CreateInstance(t));
    }
