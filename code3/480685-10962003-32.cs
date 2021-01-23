    container.ExpressionBuilt += (s, e) =>
    {
        var type = e.RegisteredServiceType;
        if (type.IsGenericType &&
            type.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
        {
            var instanceCreator = Expression.Lambda(
                Expression.Convert(e.Expression, type)).Compile();
            var constructor =
                typeof(LifetimeScopeCommandHandlerProxy<>).MakeGenericType(
                    type.GetGenericArguments()[0])
                    .GetConstructors().Single();
            // Register the proxy as singleton.
            e.Expression = Expression.Constant(
                    Expression.New(constructor,
                        Expressoin.Constant(container),
                        Expression.Constant(instanceCreator)));
        }
    };
