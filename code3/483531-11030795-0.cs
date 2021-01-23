    // read hibernate.cfg.xml
    Configuration config = new Configuration().Configure();
    // load mappings from this assembly
    config.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());
    // build factory
    ISessionFactory sessionfactory = config.BuildSessionFactory();
