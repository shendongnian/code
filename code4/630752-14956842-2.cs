    public static Expression<Func<T, bool>> GetExpression<T>(string propertyName,
                                                      string filterValue)
    {
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        var method = typeof(string).GetMethod("EndsWith", new [] { typeof(string) });
        var body = Expression.Call(property, method,
                                   Expression.Constant(filterValue));
        return (Expression<Func<T, bool>>)Expression.Lambda(body, parameter);
    }
