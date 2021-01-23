    String dllFolder = "C:\\dlls";
    public void newAppDomain()
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(assemblyResolve);
    }
    private static Assembly assemblyResolve(Object sender, ResolveEventArgs args){
        String assemblyPath = Path.Combine(dllFolder, new AssemblyName(args.Name).Name + ".dll");
        if(!File.Exists(assemblyPath))
        {
            return null;
        }
        else
        {
            return Assembly.LoadFrom(assemblyPath);
        }
    }
    private Type loadFromAppDomain(String className)
    {
        Assembly[] asses = AppDomain.CurrentDomain.GetAssemblies();
        List<Type> types = new List<Type>();
        foreach(Assembly ass in asses)
        {
            Type t = ass.GetType(className);
            if(t != null) types.Add(t);
        }
        if(types.Count == 1)
            return types.First();
        else
            return null;
    }
