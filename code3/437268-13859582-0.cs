    // Go look in all assemblies and register all implementa-
    // tions of ICommandHandler<T> by their closed interface:
    var container = new UnityContainer();
    var handlerRegistrations =
        from assembly in AppDomain.CurrentDomain.GetAssemblies()
        from implementation in assembly.GetExportedTypes()
        where !implementation.IsAbstract
        where !implementation.ContainsGenericParameters
        let services =
            from iface in implementation.GetInterfaces()
            where iface.IsGenericType
            where iface.GetGenericTypeDefinition() == 
                typeof(ICommandHandler<>)
            select iface
        from service in services
        select new { service, implementation };
        
    foreach (var registration in handlerRegistrations)
    {
        container.RegisterType(registration.service, 
            registration.implementation, "Inner1");
    }
    // Decorate each returned ICommandHandler<T> object with an
    // TransactionCommandHandlerDecorator<T>.
    container.RegisterType(typeof(ICommandHandler<>), 
        typeof(TransactionCommandHandlerDecorator<>),
        "Inner2",
        InjectionConstructor(new ResolvedParameter(
            typeof(ICommandHandler<>), "Inner1")));
    // Decorate each returned ICommandHandler<T> object with an
    // DeadlockRetryCommandHandlerDecorator<T>.
    container.RegisterType(typeof(ICommandHandler<>), 
        typeof(DeadlockRetryCommandHandlerDecorator<>), 
        InjectionConstructor(new ResolvedParameter(
            typeof(ICommandHandler<>), "Inner2")));
