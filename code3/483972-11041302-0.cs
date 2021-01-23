    // Some helper methods
    private static Type GetCommandType(Type handlerType)
    {
        return handlerType.GetGenericArguments()[0];
    }
    private static bool IsMutexCommand(Type commandType)
    {
        // Determine here is a class is a mutex command. Example:
        return typeof(IMutexCommand).IsAssignableFrom(commandType);
    }
    // Decorator registration with predicates.
    container.RegisterDecorator(
        typeof(ICommandHandler<>),
        typeof(TransactionCommandHandlerWithMutexDecorator<>),
        c => IsMutexCommand(GetCommandType(c.ServiceType)));
    // Decorator registration with predicates.
    container.RegisterDecorator(
        typeof(ICommandHandler<>),
        typeof(TransactionCommandHandlerDecorator<>),
        c => !IsMutexCommand(GetCommandType(c.ServiceType)));
