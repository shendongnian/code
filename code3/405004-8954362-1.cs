    var container = new WindsorContainer();
    container.AddFacility<TypedFactoryFacility>();
    container.Register(
        Component.For<IMessageHandlerFactory>().AsFactory(c => c.SelectedWith(new HandlerTypeSelector(container))),
        AllTypes.FromThisAssembly().BasedOn<IMessage>().WithService.AllInterfaces(),
        AllTypes.FromThisAssembly().BasedOn<IMessageHandler>().WithService.AllInterfaces()
        );
