    public static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string containsValue)
    {
        var parameterExp = Expression.Parameter(typeof(T), "type");
        var propertyExp = Expression.Property(parameterExp, propertyName);
        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var someValue = Expression.Constant(propertyValue, typeof(string));
        var containsMethodExp = Expression.Call(propertyExp, method, someValue);
        return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
    }
    public static Expression<Func<T, TKey>> GetPropertyExpression<T, TKey>(string propertyName)
    {
        var parameterExp = Expression.Parameter(typeof(T), "type");
        var exp = Expression.Property(parameterExp, propertyName);
        return Expression.Lambda<Func<T, TKey>>(exp, parameterExp);
    }
