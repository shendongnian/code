    public static bool Validate<TEntity>(this IValidatable source, ValidationInvocation invocation, IValidationContext context = null)
    	where TEntity : EntityObject
    {
    	bool? isValid = null;
    
    	foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(typeof(TEntity)))
    	{
    		var attributes = property.Attributes;
    		if (attributes.Count == 0) continue;
    
    		var value = source.GetType().GetProperty(property.Name).GetValue(source, null);
    
    		foreach (var attribute in attributes)
    		{
    			bool? result = true;
    			if (attribute.GetType().BaseType == typeof(PropertyValidationAttribute) && 
    				((PropertyValidationAttribute)attribute).Invocation.HasFlag(invocation))
    			{               
    				Type attrType = attribute.GetType();
    
    				if (attrType == typeof(RequiredAttribute))
                       	result = ValidateRequired(source, attribute as RequiredAttribute, value, property);
    				else if (attrType == typeof(RegexValidationAttribute))
    					result = ValidateRegex(source, attribute as RegexValidationAttribute, value, property);
    				//Other types of validation attribute
    
    				if (!isValid.HasValue || isValid == true) 
    					isValid = result;
    			}
    		}
    
            return isValid ?? true;
    	}
    }
