    protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<ICommonDataService, CommonDataService>(new ContainerControlledLifetimeManager());
    }
