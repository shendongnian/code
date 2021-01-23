    public void ConfigureDependencies()
    {
        ObjectFactory.Initialize(x => x.Scan(cfg =>
        {
            cfg.TheCallingAssembly();
            cfg.IncludeNamespaceContainingType<Logger>();
            cfg.ConnectImplementationsToTypesClosing(typeof(NHibernateRepository<>));
        }));
    }
    
