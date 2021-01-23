     var container = new UnityContainer();
     var container2 = new UnityContainer();
     container2.RegisterType(typeof(ICommandHandler<QueryCommand>),typeof(QueryCommandHandler));
     container.RegisterInstance("Handlers", container2);
     container.RegisterInstance(container);
     container.RegisterType(typeof(ICommandHandler<>), typeof(DecoratedHandler<>));
