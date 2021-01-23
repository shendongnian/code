    var builder = new ContainerBuilder(); 
    builder.RegisterType<SomeType>()
           .As<ISomeInterface>()
           .EnableInterfaceInterceptors()
           .InterceptedBy("my-aspect-instance");
    var interceptor = new Aspect();
    builder.RegisterInstance(interceptor)
           .Named<IInterceptor>("my-aspect-instance");
    var container = builder.Build();
    var willBeIntercepted = container.Resolve<ISomeInterface>();
