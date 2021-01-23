    public Expression Eval(object root, string propertyString)
    {
        var propertyNames = propertyString.Split('.');
        ParameterExpression param = Expression.Parameter(root.GetType, "_");
        Expression property = param;
        foreach(var prop in propertyName)
        {
            property = Expression.PropertyOrField(property, prop);
        }
        return Expression.Lambda(property, param);
    }
