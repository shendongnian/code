    container.Register<ITypeMapFactory, TypeMapFactory>();
    container.RegisterCollection<IObjectMapper>(MapperRegistry.AllMappers());
    container.RegisterSingleton<IConfiguration, ConfigurationStore>();
    container.RegisterSingleton<IConfigurationProvider, ConfigurationStore>();
    container.Register<IMappingEngine, MappingEngine>();
