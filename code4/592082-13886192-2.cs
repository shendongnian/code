    private static void foo1<T>(T o)
    {
    	var type = o.GetType();
    	var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
    	
    	foo(fields, o);
    }
    
    private static void foo(FieldInfo[] fields, object o)
    {
    	foreach (FieldInfo field in fields)
    	{
    		if (field.FieldType.IsValueType)
    		{
    			var fieldValue = field.GetValue(o);
    			//do something with the field value?
    		}
    	}
    }
