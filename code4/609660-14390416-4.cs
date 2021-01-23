    protected override Ninject.IKernel CreateKernel()
    {
        var kernel = new StandardKernel();
        kernel.Bind<RequestScopeObject>().ToSelf().InRequestScope();
        kernel.Bind<SingletonScopeObject>().ToSelf().InSingletonScope();
        return kernel;
    }
    protected override void OnApplicationStarted()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        // init cache
        this.Kernel.Get<SingletonScopeObject>().Init();
    }
