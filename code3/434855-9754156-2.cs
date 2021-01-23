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
    static void AddEventHandler(EventInfo eventInfo, object item, Action<object, EventArgs> action)
    {
      var parameters = eventInfo.EventHandlerType
        .GetMethod("Invoke")
        .GetParameters()
        .Select(parameter => Expression.Parameter(parameter.ParameterType))
        .ToArray();
      var invoke = action.GetType().GetMethod("Invoke");
      var handler = Expression.Lambda(
          eventInfo.EventHandlerType,
          Expression.Call(Expression.Constant(action), invoke, parameters[0], parameters[1]),
          parameters
        )
        .Compile();
      eventInfo.AddEventHandler(item, handler);
    }
