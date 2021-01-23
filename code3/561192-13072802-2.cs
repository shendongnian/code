    public PropertyInfo GetPropertyInfo<TProperty>(
    	Expression<Func<TProperty>> propertyLambda)
    {
    	MemberExpression member = propertyLambda.Body as MemberExpression;
    	if (member == null)
    		throw new ArgumentException(string.Format(
    			"Expression '{0}' refers to a method, not a property.",
    			propertyLambda.ToString()));
    
    	PropertyInfo propInfo = member.Member as PropertyInfo;
    	if (propInfo == null)
    		throw new ArgumentException(string.Format(
    			"Expression '{0}' refers to a field, not a property.",
    			propertyLambda.ToString()));
    
    	return propInfo;
    }
