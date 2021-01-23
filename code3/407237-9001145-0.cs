    public Expression<Func<TItem, object>> SelectExpression<TItem>(params string[] fieldNames)
    {
        var param = Expression.Parameter(typeof(TItem), "item");
        var fields = fieldNames.Select(x => Expression.Property(param, x)).ToArray();
        var types = fields.Select(x => x.Type).ToArray();
        var type = Type.GetType("System.Tuple`" + fields.Count() + ", mscorlib", true);
        var tuple = type.MakeGenericType(types);
        var ctor = tuple.GetConstructor(types);
        return Expression.Lambda<Func<TItem, object>>(
            Expression.New(ctor, fields), 
            param
        );
    }
