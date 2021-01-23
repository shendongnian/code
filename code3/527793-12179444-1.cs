    [SecurityPermission(SecurityAction.Demand, ControlAppDomain = true)]
    public static void LoadPlugins()
    {
        AppDomain.CurrentDomain.AssemblyResolve += AppDomain_AssemblyResolve;
        Assembly pluginAssembly = AppDomain.CurrentDomain.Load("MyPlugin");
    }
