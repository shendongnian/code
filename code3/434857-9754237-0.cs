    void Bar(object obj, EventInfo info)
    {
        var parameters = info.EventHandlerType.GetMethod("Invoke").GetParameters()
            .Select(p => Expression.Parameter(p.ParameterType));
        var handler = Expression.Lambda(
            info.EventHandlerType,
            Expression.Call(
                Expression.Constant(obj), // obj is the instance on which Foo()
                "Foo",                    // will be called
                null
            ),
            parameters
        );
        info.AddEventHandler(obj, handler.Compile());
    }
