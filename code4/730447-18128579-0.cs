    public static Expression<Func<T, bool>> LikeLambdaString<T>(string propertyName, string value)
    {
        var linqParam = Expression.Parameter(typeof(T), propertyName);
        var linqProp = GetProperty<T>(linqParam, propertyName);
        var containsFunc = Expression.Call(linqProp,
            typeof(string).GetMethod("Contains"),
            new Expression[] { Expression.Constant(value) });
        return Expression.Lambda<Func<T, bool>>(containsFunc,
            new ParameterExpression[] { linqParam });
    }
