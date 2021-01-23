    public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string field, string direction)
    {
        string orderByMethod;
        switch (direction)
        {
            case "ASC":
                orderByMethod = "OrderBy";
                break;
            case "DESC":
                orderByMethod = "OrderByDescending";
                break;
            default:
                throw new ArgumentException();
        }
        var propertyInfo = typeof (TSource).GetProperty(field);
        var entityParam = Expression.Parameter(typeof(TSource), "e");
        Expression columnExpr = Expression.Property(entityParam, propertyInfo);
        LambdaExpression lambdaExpression = Expression.Lambda(columnExpr, entityParam);
        MethodInfo methodInfo = 
            (from m in typeof(Queryable).GetMethods()
                where m.Name == orderByMethod
                let parameterInfo = m.GetParameters()
                where parameterInfo.Length == 2
                && parameterInfo[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)
                && parameterInfo[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>)
                select m
            ).Single();
        MethodInfo orderBy = methodInfo.MakeGenericMethod(new [] {typeof(TSource), propertyInfo.PropertyType});
        return (IQueryable<TSource>) orderBy.Invoke(null, new object[] { source, lambdaExpression });
    }
