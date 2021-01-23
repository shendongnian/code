    Type runtimeType = args.Instance.GetType();
    EventInfo runtimeEvent =
        runtimeType.GetEvents().Where( e => e.Name == _event.Name ).First();
    
    MethodInfo delegateInfo =
        DelegateHelper.MethodInfoFromDelegateType( runtimeEvent.EventHandlerType );
    ParameterExpression[] parameters = delegateInfo
        .GetParameters()
        .Select( p => Expression.Parameter( p.ParameterType ) )
        .ToArray();
    Delegate emptyDelegate = Expression.Lambda(
        runtimeEvent.EventHandlerType, Expression.Empty(),
        "EmptyDelegate", true, parameters ).Compile();
    
    // Add the empty handler to the instance.
    MethodInfo addMethod = runtimeEvent.GetAddMethod( true );
    if ( addMethod.IsPublic )
    {
    	runtimeEvent.AddEventHandler( args.Instance, emptyDelegate );
    }
    else
    {
    	addMethod.Invoke( args.Instance, new object[] { emptyDelegate } );
    }
