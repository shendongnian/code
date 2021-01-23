    public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string field, string direction)
    {
        string orderByMethod = (direction == "ASC") ? "OrderBy" : (direction == "DESC" ? "OrderByDescending" : null);
        if(orderByMethod == null) throw new ArgumentException();
        var propertyInfo = typeof (TSource).GetProperty(field);
        var entityParam = Expression.Parameter(typeof(TSource), "e");
        Expression columnExpr = Expression.Property(entityParam, propertyInfo);
        LambdaExpression columnLambda = Expression.Lambda(columnExpr, entityParam);
        MethodInfo orderByGeneric =  typeof (Queryable).GetMethods().Single(m => m.Name == orderByMethod
                                                        && m.GetParameters().Count() == 2
                                                        && m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)
                                                        && m.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>));
        MethodInfo orderBy = orderByGeneric.MakeGenericMethod(new [] {typeof(TSource), propertyInfo.PropertyType});
        return (IQueryable<TSource>) orderBy.Invoke(null, new object[] { source, columnLambda });
    }
