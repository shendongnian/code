    EventInfo _event;
    ...
    MethodInfo delegateInfo
        = DelegateHelper.MethodInfoFromDelegateType( _event.EventHandlerType );
    ParameterExpression[] parameters = delegateInfo
        .GetParameters()
        .Select( p => Expression.Parameter( p.ParameterType ) )
        .ToArray();
    Delegate emptyDelegate = Expression.Lambda(
        _event.EventHandlerType,
        Expression.Empty(), "EmptyDelegate", true, parameters ).Compile();
