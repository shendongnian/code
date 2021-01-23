    public static T GenerateFunc<T>(Type type)
    {
        var target = typeof (Program).GetMethod("Target");
        var invokeMethod = type.GetMethod("Invoke");
        var parameters = invokeMethod
          .GetParameters()
          .Select(pi => Expression.Parameter(pi.ParameterType, pi.Name))
          .ToList();
        var parametersExpression = Expression.NewArrayInit(typeof(object), parameters);
        var body = Expression.Call(target, parametersExpression);
        return Expression.Lambda<T>(body, parameters).Compile();
    }
