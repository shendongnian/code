    public NinjectDependencyResolver() {
        _kernal = new StandardKernel();
       AddBindings();
    }
    
    public void AddBindings() {
        Bind<ISomething>().To<Somehting>();
    }
