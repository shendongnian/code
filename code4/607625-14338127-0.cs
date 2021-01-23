    public static IKernel InitializeKernel() 
    { 
        var kernel = new StandardKernel();
     
        // binding for production
        kernel
            .Bind<IBackend>()
            .To<ProdBackend>()
            .When(request => IsCurrentEnvironmentProduction());
        
        // binding for test environment
        kernel
            .Bind<IBackend>()
            .To<TestBackend>()
            .When(request => !IsCurrentEnvironmentProduction());
     
        return kernel; 
    }
