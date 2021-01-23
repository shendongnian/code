    public interface IMappingHandler
    {
    }
    //NOTE: None of this code was tested...but it'll be close(ish)..
    protected void AutoMapperConfig()
    {
        //If the assemblies are located in the bin directory:
        var assemblies = Directory.GetFiles(HttpRuntime.BinDirectory, "*.dll");
			
        //Otherwise, use something like the following:
        var assemblies = Directory.GetFiles("C:\\SomeDirectory\\", "*.dll");
        //Define some sort of other filter...a base type for example.
        var baseType = typeof(IMappingHandler);
        foreach (var file in assemblies)
        {
            //There are other ways to optimize this query.
            var types = (from t in Assembly.LoadFrom(file).GetExportedTypes()
                         where t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t)
                         select t).ToList();
            //Assuming all the queried types defined a default constructor.
            types.ForEach(t => Activator.CreateInstance(t));
        }
    }
