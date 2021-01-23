    public static IQueryable<IGrouping<object, T>> GroupBy<T>(this IQueryable<T> source, string propertyName)
    {
        ParameterExpression param = Expression.Parameter(typeof(T), String.Empty);
        MemberExpression property = Expression.PropertyOrField(param, propertyName);
        UnaryExpression convert = Expression.Convert(property, typeof(object));
        LambdaExpression group = Expression.Lambda(convert, param);
        MethodCallExpression call = Expression.Call(
            typeof(Queryable),
            "GroupBy",
            new[] { typeof(T), typeof(object) },
            source.Expression,
            Expression.Quote(group));
        return source.Provider.CreateQuery<IGrouping<object, T>>(call);
    }
