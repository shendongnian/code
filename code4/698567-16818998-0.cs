    container.RegisterType<IUnitOfWork, MyDbContext>(
        new HierarchicalLifetimeManager(),
        new InjectionFactory(
            c => new MyDbContext(configurationService.MySqlConnectionString)
        )
    );
    container.RegisterType<DbContext, MyDbContext>(
        new HierarchicalLifetimeManager()
    );
