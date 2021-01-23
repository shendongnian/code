    public static Action<object, object> GetValueSetter(this PropertyInfo propertyInfo)
    {
        var instance = Expression.Parameter(typeof(object), "i");
        var argument = Expression.Parameter(typeof(object), "a");
        var setterCall = Expression.Call(
            Expression.Convert(instance, propertyInfo.DeclaringType),
            propertyInfo.GetSetMethod(),
            Expression.Convert(argument, propertyInfo.PropertyType));
        return (Action<object, object>)Expression.Lambda(setterCall, instance, argument).Compile();
    }
