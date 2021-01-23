    var properties = typeof(TType).GetProperties().Where(p => p.CanRead);
    foreach (var propertyInfo in properties)
    {
        MethodInfo getterMethodInfo = propertyInfo.GetGetMethod();
        ParameterExpression entity = Expression.Parameter(typeof(TType));
        MethodCallExpression getterCall = Expression.Call(entity, getterMethodInfo);
        UnaryExpression castToObject = Expression.Convert(getterCall, typeof(object));
        LambdaExpression lambda = Expression.Lambda(castToObject, entity);
        var functionThatGetsValue = (Func<TType, object>)lambda.Compile();
    }
