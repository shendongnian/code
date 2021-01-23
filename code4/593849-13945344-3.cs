    public static Func<T, object> ToLambda<T>(this string propertyName)
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "x"); // x
        Expression property = Expression.Property(param, propertyName);   // x.PropertyName
        Func<T, object> lambda = Expression.Lambda<Func<T, object>>(      // x => x.PropertyName
                Expression.Convert(property, typeof(object)),
                param)
            .Compile();
        return lambda;
    }
