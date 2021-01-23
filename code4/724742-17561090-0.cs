    public class StringLength : Attribute
    {
    	public int MaximumLength;
    	
    	public static int Get<TProperty>(Expression<Func<TProperty>> propertyLambda)
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
    	
    		var stringLengthAttributes = propInfo.GetCustomAttributes(typeof(StringLength), true);
    		if (stringLengthAttributes.Length > 0)
    			return ((StringLength)stringLengthAttributes[0]).MaximumLength;
    		
    		return -1;
    	}
    }
