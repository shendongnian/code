    private static Func<object, object> BuildExpression(
        Type type, string propertyName)
    {
        var parameter = Expression.Parameter(typeof(object));
        var body = Expression.TypeAs(Expression.PropertyOrField(Expression.TypeAs(
            parameter, type), propertyName), typeof(object));
        return Expression.Lambda<Func<object, object>>(body, parameter).Compile();
    }
