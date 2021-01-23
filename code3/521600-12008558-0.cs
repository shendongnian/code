    private void LogLoadedAssemblies()
    {
        var log = LogManager.GetLogger("AssemblyLoadHandler");
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            log.Info("Already loaded: " + assembly.FullName + " (" + (assembly.IsDynamic ? "dynamic" : assembly.Location) + ")");
        }
    }
    static void AssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args)
    {
        LogManager.GetLogger("AssemblyLoadHandler").Info("Assembly loaded: " + args.LoadedAssembly.FullName + " (" + (args.LoadedAssembly.IsDynamic ? "dynamic" : args.LoadedAssembly.Location) + ")");
    }
