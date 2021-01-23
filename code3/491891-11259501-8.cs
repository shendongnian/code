    var controllerTypes =
        from type in Assembly.GetExecutingAssembly().GetExportedTypes()
        where typeof(IHttpController).IsAssignableFrom(type)
        where !type.IsAbstract
        where !type.IsGenericTypeDefinition
        where type.Name.EndsWith("Controller", StringComparison.Ordinal)
        select type;
    foreach (var controllerType in controllerTypes)
    {
        container.Register(controllerType);
    }
