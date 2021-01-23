    public Type[] LoadType(string typeName)
    {
        return LoadType(typeName, true);
    }
    public Type[] LoadType(string typeName, bool referenced)
    {
        return LoadType(typeName, referenced, true);
    }
    private Type[] LoadType(string typeName, bool referenced, bool gac)
    {
        //check for problematic work
        if (string.IsNullOrEmpty(typeName) || !referenced && !gac)
            return new Type[] { };
        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        List<string> assemblyFullnames = new List<string>();
        List<Type> types = new List<Type>();
        if (referenced)
        {            //Check refrenced assemblies
            foreach (AssemblyName assemblyName in currentAssembly.GetReferencedAssemblies())
            {
                //Load method resolve refrenced loaded assembly
                Assembly assembly = Assembly.Load(assemblyName.FullName);
                //Check if type is exists in assembly
                var type = assembly.GetType(typeName, false, true);
                if (type != null && !assemblyFullnames.Contains(assembly.FullName))
                {
                    types.Add(type);
                    assemblyFullnames.Add(assembly.FullName);
                }
            }
        }
        if (gac)
        {
            //GAC files
            string gacPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Windows) + "\\assembly";
            var files = GetGlobalAssemblyCacheFiles(gacPath);
            foreach (string file in files)
            {
                try
                {
                    //reflection only
                    Assembly assembly = Assembly.ReflectionOnlyLoadFrom(file);
                    //Check if type is exists in assembly
                    var type = assembly.GetType(typeName, false, true);
                    if (type != null && !assemblyFullnames.Contains(assembly.FullName))
                    {
                        types.Add(type);
                        assemblyFullnames.Add(assembly.FullName);
                    }
                }
                catch
                {
                    //your custom handling
                }
            }
        }
        return types.ToArray();
    }
    public static string[] GetGlobalAssemblyCacheFiles(string path)
    {
        List<string> files = new List<string>();
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (FileInfo fi in di.GetFiles("*.dll"))
        {
            files.Add(fi.FullName);
        }
        foreach (DirectoryInfo diChild in di.GetDirectories())
        {
            var files2 = GetGlobalAssemblyCacheFiles(diChild.FullName);
            files.AddRange(files2);
        }
        return files.ToArray();
    }
