    //initilization
    var builder = new ContainerBuilder();
    builder.RegisterType<MyService>().As<IMyService>().InstancePerLifetimeScope();
    var container = builder.Build();
     
    //any point of your app
    Data mData = new Data("runtimeData"); // must to be accesible in every place you Resolve
    
    using(var scope = container.BeginLifetimeScope())
    {
      
      var service = scope.Resolve<IMyService>(new TypedParameter(typeof(Data), mData));
    service.DoStuff();
    }
    
    using(var scope = container.BeginLifetimeScope())
    {
      
      var service2 = scope.Resolve<IMyService>(new TypedParameter(typeof(Data), mData));
    service2.DoStuff();
    }
