    void Register(Type serviceType, object service)
    {
        // ... some argument validation
        if (!(serviceType.IsAssignableFrom(service.GetType())))
            throw...
        // ... register logic
    }
    //usage:
    void InitializeServices()
    {
        Register(typeof(IService), new Service());
    }
