    // 3 kernel configuration
    public static IKernel InitializeKernel() 
    { 
        var kernel = new StandardKernel();
    
        kernel.Bind(x => x
             // 3.1 search in current assembly
            .FromThisAssembly()
                .SelectAllClasses() // 3.2 select all classes implement "special" interface
                .InheritedFrom<IShippingCompanyService>()
            // 3.3 search all assemblies by wildcards
            .Join.FromAssembliesMatching("./*Services.dll")
                .SelectAllClasses() // 3.2 select all classes implement special interface
                .InheritedFrom<IShippingCompanyService>()
            // 3.4 bind to "special" interface
            .BindAllInterfaces()
            // 3.5 configure lifetime management and dependency name
            .Configure((b, c) => 
                b.InTransientScope().Named(c.Name)));
    
        return kernel; 
    } 
