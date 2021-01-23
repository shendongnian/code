    IUnityContainer container = new UnityContainer();
    container.RegisterType<IDbManager, SqlDbManager>();
    container.RegisterType<ICacheProvider, MemoryCaching>();
    container.RegisterType<IEventRepository, EventRepository>();
    container.RegisterType<IEventRepository, CachedEventRepository>(
        new InjectionConstructor(
            new ResolvedParameter<EventRepository>(),
            new ResolvedParameter<ICacheProvider>())
        );
