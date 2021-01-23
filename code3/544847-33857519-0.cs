    var commandTypes = businessAssembly.GetTypes()
        .Where(t => !t.IsInterface && typeof(ICommand).IsAssignableFrom(t));
    foreach(var commandType in commandTypes)
    {
        var handlerInterface = typeof(ICommandHandler<>).MakeGenericType(new[] { commandType });
        var transactionalHandler = typeof(DeadlockRetryCommandHandlerDecorator<>).MakeGenericType(new[] { commandType });
        container.Register(Component.For(handlerInterface)
            .ImplementedBy(transactionalHandler)
            .LifeStyle.PerWebRequest);
    }
