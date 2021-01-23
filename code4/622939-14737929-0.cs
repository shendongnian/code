    public static Expression<Func<TSource, TResult>>
        GenerateSelector<TSource, TResult>(string propertyOrFieldName)
    {
        var parameter = Expression.Parameter(typeof(TSource));
        var body = Expression.Convert(
            // generate the appropriate member access
            Expression.PropertyOrField(parameter, propertyOrFieldName),
            typeof(TResult)
        );
        var expr = Expression.Lambda<Func<TSource, TResult>>(body, parameter);
        return expr;
    }
