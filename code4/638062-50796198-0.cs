    private static bool gAutoLoad = ExecuteBeforeMain();
    private static bool ExecuteBeforeMain()
    {
        // Note: AssemblyResolve only occurs when the resolution of an assembly fails.
        AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveErrorHandler;
        return true;
    }
    
    private static System.Reflection.Assembly AssemblyResolveErrorHandler(object sender, ResolveEventArgs args)
    { ... }
