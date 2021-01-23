    public static void RegisterApiControllers(
        this Container container, IHttpControllerTypeResolver typeResolver = null)
    {
        if (container == null)
        {
            throw new ArgumentNullException("container");
        }
        typeResolver = typeResolver ?? GlobalConfiguration
            .Configuration.Services.GetHttpControllerTypeResolver();
        foreach (var controllerType in typeResolver.GetCo‌​ntrollerTypes())
        {
            container.Register(controllerType);
        }
    }
