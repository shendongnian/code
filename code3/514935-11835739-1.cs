    var builder = new ContainerBuilder();
    builder.Register(con => new SomeDependancy()).AsSelf().InstancePerHttpRequest();
    // builder.RegisterType<CustomFilter>().As<IActionFilter>().PropertiesAutowired();
    // property injection on filters
    builder.RegisterFilterProvider();
    
    // Needed to allow property injection in custom action filters.
    builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();
    
    builder.RegisterControllers(typeof(MvcApplication).Assembly).InjectActionInvoker();
    
    var container = builder.Build();
    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
