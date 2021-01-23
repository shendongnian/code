    // Void delegate with three parameters
    static public Delegate Create<T>(EventInfo eventInformation, Action<T, T, T> lambdaDelegate)
    {
        var handlerType = eventInformation.EventHandlerType;
        var eventParams = handlerType.GetMethod("Invoke").GetParameters();
        //lambda: (object x0, ExampleEventArgs x1) => d(x1.X,x1.Y,x1.Z)
        var parameters = eventParams.Select(p => Expression.Parameter(p.ParameterType, "x")).ToArray();
        var arg = getArgExpression(parameters[1], typeof(T));
        var body = Expression.Call(Expression.Constant(lambdaDelegate), lambdaDelegate.GetType().GetMethod("Invoke"), arg);
        var lambda = Expression.Lambda(body, parameters);
        return Delegate.CreateDelegate(handlerType, lambda.Compile(), "Invoke", false);
    }
