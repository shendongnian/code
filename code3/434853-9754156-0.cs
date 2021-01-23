    static void AddEventHandler(EventInfo eventInfo, object item,  Action action)
    {
      var parameters = eventInfo.EventHandlerType
        .GetMethod("Invoke")
        .GetParameters()
        .Select(parameter => Expression.Parameter(parameter.ParameterType))
        .ToArray();
      var handler = Expression.Lambda(
          eventInfo.EventHandlerType, 
          Expression.Call(Expression.Constant(action), "Invoke", Type.EmptyTypes), 
          parameters
        )
        .Compile();
      eventInfo.AddEventHandler(item, handler);
    }
