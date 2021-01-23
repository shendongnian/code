    public static Expression CreateExpression<T>(string propertyName, object valueToCompare)
    {
    	// get the type of entity
    	var entityType = typeof(T);
    	// get the type of the value object
    	var valueType = valueToCompare.GetType();
    	var entityProperty = entityType.GetProperty(propertyName);
    	var propertyType = entityProperty.PropertyType;
    	
    	
    	// Expression: "entity"
    	var parameter = Expression.Parameter(entityType, "entity");
    	
    	// check if the property type is a value type
    	// only value types work 
    	if (propertyType.IsValueType || propertyType.Equals(typeof(string)))
    	{
    		// Expression: entity.Property == value
    		return Expression.Equal(
    			Expression.Property(parameter, entityProperty),
    			Expression.Constant(valueToCompare)
    		);
    	}
    	// if not, then use the key
    	else
    	{
    		// get the key property
    		var keyProperty = propertyType.GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Length > 0);
    
    		// Expression: entity.Property.Key == value.Key
    		return Expression.Equal(
    			Expression.Property(
    				Expression.Property(parameter, entityProperty),
    				keyProperty
    			),
    			Expression.Constant(
    				keyProperty.GetValue(valueToCompare),
    				keyProperty.PropertyType
    			)
    		);
    	}
    }
