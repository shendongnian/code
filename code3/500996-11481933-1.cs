    	//Try Parse using Reflection
    public static bool TryConvertValue<T>(string stringValue, out T convertedValue)
    {
    	var targetType = typeof(T);
    	if (targetType == typeof(string))
    	{
    		convertedValue = (T)Convert.ChangeType(stringValue, typeof(T));
    		return true;
    	}
    		var nullableType = targetType.IsGenericType &&
    					   targetType.GetGenericTypeDefinition() == typeof (Nullable<>);
    	if (nullableType)
    	{
    		if (string.IsNullOrEmpty(stringValue))
    		{
    			convertedValue = default(T);
    			return true;
    		}
    			targetType = new NullableConverter(targetType).UnderlyingType;
    	}
    
    	Type[] argTypes = { typeof(string), targetType.MakeByRefType() };
    	var tryParseMethodInfo = targetType.GetMethod("TryParse", argTypes);
    	if (tryParseMethodInfo == null)
    	{
    		convertedValue = default(T);
    		return false;
    	}
    
    	object[] args = { stringValue, null };
    	var successfulParse = (bool)tryParseMethodInfo.Invoke(null, args);
    	if (!successfulParse)
    	{
    		convertedValue = default(T);
    		return false;
    	}
    
    	convertedValue = (T)args[1];
    	return true;
    }
