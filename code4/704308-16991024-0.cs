    public static TTarget ConvertDelegate<TSource, TTarget>(TSource sourceDelegate)
    {
        if (!typeof(Delegate).IsAssignableFrom(typeof(TSource)))
            throw new InvalidOperationException("TSource must be a delegate.");
        if (!typeof(Delegate).IsAssignableFrom(typeof(TTarget)))
            throw new InvalidOperationException("TTarget must be a delegate.");
        if (sourceDelegate == null)
            throw new ArgumentNullException("sourceDelegate");
        var parameterExpressions = typeof(TTarget)
            .GetMethod("Invoke")
            .GetParameters()
            .Select(p => Expression.Parameter(p.ParameterType))
            .ToArray();
        var sourceParametersCount = typeof(TSource)
            .GetMethod("Invoke")
            .GetParameters()
            .Length;
        var expression = Expression.Lambda<TTarget>(
            Expression.Invoke(
                Expression.Constant(sourceDelegate),
                parameterExpressions.Take(sourceParametersCount)),
            parameterExpressions);
        return expression.Compile();
    }
