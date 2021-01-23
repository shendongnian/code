    public static Expression<Func<TTo, TR>> Convert<TFrom, TR>(
        Expression<Func<TFrom, TR>> e)
    {
        var oldParameter = e.Parameters[0];
        var newParameter = Expression.Parameter(typeof(TTo), oldParameter.Name);
        var converter = new ConversionVisitor(newParameter, oldParameter);
        var newBody = converter.Visit(e.Body);
        return Expression.Lambda<Func<TTo, TR>>(newBody, newParameter);
    }
