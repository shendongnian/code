    public static string Magic_GetName<TClass, TProperty>(
        Expression<Func<TClass, TProperty>> propertyExpression)
    {
        var body = propertyExpression.Body as MemberExpression;
        if (body == null)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture, 
                    "'propertyExpression' should be a member expression, " +
                    "but it is a {0}", 
                    propertyExpression.Body.GetType()));
        }
        var propertyInfo = body.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture, 
                    "The member used in the expression should be a property, " +
                    "but it is a {0}", 
                    body.Member.GetType()));
        }
        return propertyInfo.Name;
    }
