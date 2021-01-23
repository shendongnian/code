    var builder = new ContainerBuilder(); 
    builder.RegisterType<SomeType>()
           .As<ISomeInterface>()
           .EnableInterfaceInterceptors(); 
    builder.Register(c => new CallLogger(Console.Out));
    var container = builder.Build();
    var willBeIntercepted = container.Resolve<ISomeInterface>();
