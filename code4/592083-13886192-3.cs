    private static void foo1<T>(T o)
    {
    	var type = o.GetType();
    	var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
    	
    	foo(properties, o);
    }
    
    private static void foo(PropertyInfo[] properties, object o)
    {
    	foreach (PropertyInfo property in properties)
    	{
    		if (property.PropertyType.IsValueType)
    		{
    			var propertyValue = property.GetValue(o, null);
    			//do something with the property value?
    		}
    	}
    }
