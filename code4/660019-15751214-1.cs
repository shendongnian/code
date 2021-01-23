    public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyOrFieldName, object value)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var prop = Expression.Property(param, name);
        var @const = Expression.Constant(value, prop.Type);
        var equals = Expression.Equal(prop, @const);
        var lambda = Expression.Lambda(equals, param);
        return source.Where(lambda);
    }
    foreach(var p in parameters)
    {
        query = query.Where(p.Key, p.Value);
    }
