    container.Register<ITypeMapFactory, TypeMapFactory>();
    container.RegisterAll<IObjectMapper>(
        MapperRegistry.AllMappers());
    container.RegisterSingle<ConfigurationStore>();
    container.Register<IConfiguration>(() => 
        container.GetInstance<ConfigurationStore>());
    container.Register<IConfigurationProvider>(() => 
        container.GetInstance<ConfigurationStore>());
    container.Register<IMappingEngine, MappingEngine>();
