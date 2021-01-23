    Expression<Func<YourResultType, string>> CreateExpression(string propertyName)
    {
        var itemExpression = Expression.Parameter(typeof(YourResultType), "item");
        var propertyExpression = Expression.Property(itemExpression, propertyName);
        var toStringExpression = Expression.Call(propertyExpression,
                                                 "ToString", null);
        return Expression.Lambda<Func<YourResultType, string>>(toStringExpression, 
                                                               itemExpression);
    }
