    var container = new Container();
    //Register you types in container here
    container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
    container.RegisterMvcAttributeFilterProvider();
    var controllerTypes =
    from type in Assembly.GetExecutingAssembly().GetExportedTypes()
    where typeof(ApiController).IsAssignableFrom(type)
    where !type.IsAbstract
    where !type.IsGenericTypeDefinition
    where type.Name.EndsWith("Controller", StringComparison.Ordinal)
    select type;
    foreach (var controllerType in controllerTypes)
    {
        container.Register(controllerType);
    }
    container.Verify();
    DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
