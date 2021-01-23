    public static string GetName<TClass>(
        Expression<Func<TClass, object>> propertyExpression)
    {
        var body = propertyExpression.Body as UnaryExpression;
        var memberExpression = body.Operand as MemberExpression;
        var propertyInfo = memberExpression.Member as PropertyInfo;
        
        return propertyInfo.Name;
    }
