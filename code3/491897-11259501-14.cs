    var services = GlobalConfiguration.Configuration.Services;
    var controllerTypes = services.GetHttpControllerTypeResolver()
        .GetControllerTypes(services.GetAssembliesResolver());
    foreach (var controllerType in controllerTypes)
    {
        container.Register(controllerType);
    }
