    private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
    {
        PropertyInfo prop = typeof(T).GetProperty(propertyName);
        ParameterExpression paramExpr = Expression.Parameter(typeof(T), "obj");
        MemberExpression propExpr = Expression.Property(paramExpr, prop);
    
        Type funcType = typeof(Func<,>).MakeGenericType(typeof(T), prop.PropertyType);
        Type keySelectorType = typeof(Expression<>).MakeGenericType(funcType);
        LambdaExpression keySelector = Expression.Lambda(funcType, propExpr, paramExpr);
    
        MethodInfo orderByMethod = typeof(Queryable).GetMethods().Single(m => m.Name == "OrderBy" && m.GetParameters().Length == 2).MakeGenericMethod(typeof(T), prop.PropertyType);
        return (IOrderedQueryable<T>) orderByMethod.Invoke(null, new object[] { source, keySelector });
    }
