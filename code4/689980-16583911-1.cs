    public Expression<Func<Foo, bool>> GetExpression<T>(
        int setSize, int[] elements,
        Expression<Func<Foo, T>> property)
    {
        var seedProperty = GetPropertyInfo(property);
    	var parameter = Expression.Parameter(typeof(Foo));
        Expression body = null;
        
        foreach(var element in elements)
        {
            var condition = GetCondition(parameter, seedProperty, setSize, element);
            if(body == null)
    	        body = condition;
            else
                body = Expression.OrElse(body, condition);
        }
        
        return Expression.Lambda<Func<Foo, bool>>(body, parameter);    
    }
    
    public Expression GetCondition(
        ParameterExpression parameter, PropertyInfo seedProperty,
        int setSize, int element)
    {
        return Expression.Equal(
    	    Expression.Modulo(Expression.Property(parameter, seedProperty),
                              Expression.Constant(setSize)),
            Expression.Constant(element));
    }
    public static PropertyInfo GetPropertyInfo(LambdaExpression propertyExpression)
    {
        if (propertyExpression == null)
            throw new ArgumentNullException("propertyExpression");
        var body = propertyExpression.Body as MemberExpression;
        if (body == null)
        {
            throw new ArgumentException(
                string.Format(
                    "'propertyExpression' should be a member expression, but it is a {0}", 
                    propertyExpression.Body.GetType()));
        }
        var propertyInfo = body.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new ArgumentException(
                string.Format(
                    "The member used in the expression should be a property, but it is a {0}", 
                    body.Member.GetType()));
        }
        return propertyInfo;
    }
