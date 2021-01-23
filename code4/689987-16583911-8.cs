    public static Expression<Func<TEntity, bool>> GetExpression<TEntity, TProperty>(
        int setSize, int[] elements,
        Expression<Func<TEntity, TProperty>> property)
    {
        var propertyInfo = GetPropertyInfo(property);
        var parameter = Expression.Parameter(typeof(TEntity));
        Expression body = null;
    
        foreach(var element in elements)
        {
            var condition = GetCondition(parameter, propertyInfo , setSize, element);
            if(body == null)
                body = condition;
            else
                body = Expression.OrElse(body, condition);
        }
        if(body == null)
            body = Expression.Constant(false);
    
        return Expression.Lambda<Func<TEntity, bool>>(body, parameter);    
    }
