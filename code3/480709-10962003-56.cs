    container.RegisterLifetimeScope<IUnitOfWork, UnitOfWork>();
    
    container.RegisterManyForOpenGeneric(
        typeof(ICommandHandler<>),
        AppDomain.CurrentDomain.GetAssemblies());
    // Register a decorator that handles saving the unit of
    // work after a handler has executed successfully.
    // This decorator will wrap all command handlers.
    container.RegisterDecorator(
        typeof(ICommandHandler<>),
        typeof(TransactionCommandHandlerDecorator<>));
    
    // Register the proxy that starts a lifetime scope.
    // This proxy will wrap the transaction decorators.
    container.RegisterSingleDecorator(
        typeof(ICommandHandler<>),
        typeof(LifetimeScopeCommandHandlerProxy<>));
