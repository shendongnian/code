    var builder = new ContainerBuilder(); 
    builder.RegisterType<SomeType>()
           .As<ISomeInterface>()
           .EnableInterfaceInterceptors()
           .InterceptedBy(typeof(Aspect));
    var interceptor = new Aspect();
    builder.RegisterInstance(interceptor);
    var container = builder.Build();
    var willBeIntercepted = container.Resolve<ISomeInterface>();
