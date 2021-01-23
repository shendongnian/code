    public static IContainer SetupContainer(HttpConfiguration config)
    {
        var containerBuilder = new ContainerBuilder();
    
        // Register your Web API.
        containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        containerBuilder.RegisterHttpRequestMessage(config);
        containerBuilder.Register<UrlHelper>(x => new UrlHelper(x.Resolve<HttpRequestMessage>()));  
        containerBuilder.RegisterWebApiFilterProvider(config);
        containerBuilder.RegisterWebApiModelBinderProvider();
    
        // Register your other types...
    
        var container = containerBuilder.Build();
    
        // Set the dependency resolver to be Autofac.
        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    
        return container;
    }
