    public class Core
    {
        List<IPlugin> plugins = new List<IPlugin>();
        string path;
    public Core(string path)
    {
        this.path = path;
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        LoadPlugins();
        foreach (IPlugin plugin in plugins)
            plugin.Work();
    }
    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in currentAssemblies)
        {
            if (assembly.FullName == args.Name)
            {
                Console.WriteLine("resolved assembly " + args.Name + " using exising appdomain");
                return assembly;
            }
        }
        var file = args.Name.Split(new char[] { ',' })[0].Replace(@"\\", @"\");
        var dll = Path.Combine(path, file) + ".dll";
        Console.WriteLine("resolved assembly " + args.Name + " from " + path);
        return File.Exists(dll) ? Assembly.LoadFrom(dll) : null;
    }
    void LoadPlugins()
    {
        foreach (string file in Directory.GetFiles(this.path, "*.dll"))
        {
            FileInfo fileInfo = new FileInfo(file);
            Assembly dllAssembly = Assembly.LoadFile(file);
            foreach (Type type in dllAssembly.GetTypes())
            {
                Type typeInterface = type.GetInterface("Problems.IPlugin");
                if (typeInterface != null)
                    plugins.Add((IPlugin)Activator.CreateInstance(
                                    dllAssembly.GetType(type.ToString())));
            }
        }
    }
    }
