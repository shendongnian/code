    static Expression<Func<TModel,TProperty>> CreateExpression<TModel,TProperty>(
        string propertyName)
    {
        var param = Expression.Parameter(typeof(TModel), "x");
        return Expression.Lambda<Func<TModel, TProperty>>(
            Expression.PropertyOrField(param, propertyName), param);
    }
