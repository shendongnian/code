    public static Boolean TrySettingPropertyValue(Object target, String property, String value)
    {
    		if (target == null)
    			return false;
    		try
    		{
    			var prop = target.GetType().GetProperty(property, DefaultBindingFlags);
    			if (prop == null)
    				return false;
    			if (value == null)
    				prop.SetValue(target,null,null);
    			var convertedValue = Convert.ChangeType(value, prop.PropertyType);
    			prop.SetValue(target,convertedValue,null);
    			return true;
    		}
    		catch
    		{
    			return false;
    		}
    		
    	}
