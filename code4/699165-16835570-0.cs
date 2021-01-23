    public static class ObjectExtensions
    {
    	public static T SetStringPropertiesOnly<T>(this T obj) where T : class
    	{
    		var fields = obj.GetType().GetProperties();
    
    		foreach (var field in fields)
    		{
    			if (field.PropertyType == typeof (string))
    			{
    				field.SetValue(obj, "blablalba", null); //set value or do w/e your want
    			}
    		}
    		return obj;
    
    	}
    }
