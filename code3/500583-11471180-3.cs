    public NinjectDependencyResolver() {
        _kernal = new StandardKernel();
        RegisterServices(_kernel);
    }
    
    public static void RegisterServices(IKernel kernel) {
        kernel.Bind<ISomething>().To<Something>();
    }
