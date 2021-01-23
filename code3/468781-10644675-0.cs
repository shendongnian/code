    public static bool IsPerformingPrecompilation()
    {
        var simpleApplicationHost = Assembly.GetAssembly(typeof(HostingEnvironment))
                                        .GetType("System.Web.Hosting.SimpleApplicationHost", throwOnError: true, ignoreCase: true);
        return HostingEnvironment.InClientBuildManager && 
               HostingEnvironment.ApplicationID.EndsWith("_precompile", StringComparison.InvariantCultureIgnoreCase) && 
               HostingEnvironment.ApplicationHost.GetType() == simpleApplicationHost;
    }
