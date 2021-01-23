    var properties = typeof(TType).GetProperties().Where(p => p.CanRead);
    foreach (var propertyInfo in properties)
    {
        var getterMethodInfo = propertyInfo.GetGetMethod();
        var entity = Expression.Parameter(typeof(TType));
        var getterCall = Expression.Call(entity, getterMethodInfo);
        var castToObject = Expression.Convert(getterCall, typeof(object));
        var lambda = Expression.Lambda(castToObject, entity);
        var functionThatGetsValue = (Func<TType, object>)lambda.Compile();
    }
