    /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
    public static void Initialize()
    {
        var container = new Container();
        InitializeContainer(container);
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        container.RegisterMvcAttributeFilterProvider();
        container.Verify();
        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
    
        RegisterGlobalFilters(GlobalFilters.Filters, container);
    }
