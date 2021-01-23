    public Expression<Func<TItem, object>> SelectExpression<TItem>(string[] propertyNames)
    {
        var properties = propertyNames.Select(name => typeof(TItem).GetProperty(name)).ToArray();
        var propertyTypes = properties.Select(p => p.PropertyType).ToArray();
        var tupleTypeDefinition = typeof(Tuple).Assembly.GetType("System.Tuple`" + properties.Length);
        var tupleType = tupleTypeDefinition.MakeGenericType(propertyTypes);
        var constructor = tupleType.GetConstructor(propertyTypes);
        var param = Expression.Parameter(typeof(TItem), "item");
        var body = Expression.New(constructor, properties.Select(p => Expression.Property(param, p)));
        var expr = Expression.Lambda<Func<TItem, object>>(body, param);
        return expr;
    }
