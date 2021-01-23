    public static string Magic_GetName<TClass>(
        Expression<Func<TClass, object>> propertyExpression)
    {
        propertyExpression.Dump();
        var body = propertyExpression.Body as UnaryExpression;
        if (body == null)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture, 
                    "The body of the 'propertyExpression' should be an " +
                    "unary expression, but it is a {0}", 
                    propertyExpression.Body.GetType()));
        }
        
        var memberExpression = body.Operand as MemberExpression;
        if (memberExpression == null)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture, 
                    "The operand of the body of 'propertyExpression' should " +
                    "be a member expression, but it is a {0}", 
                    propertyExpression.Body.GetType()));
        }
        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture, 
                    "The member used in the expression should be a property, " +
                    "but it is a {0}", 
                    memberExpression.Member.GetType()));
        }
    
        return propertyInfo.Name;
    }
