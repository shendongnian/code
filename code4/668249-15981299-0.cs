    // extension
    public static string AttributeToString<T>(this object obj, string propertyName)
    	where T: Attribute
    {
    	MemberInfo property = obj.GetType().GetProperty(propertyName);
    
    	var attribute = default(T);
    	if (property != null)
    	{
    		attribute = property.GetCustomAttributes(typeof(T), true)
    							.Cast<T>().Single();
    	}
    	return attribute == null ? string.Empty : attribute.ToString();
    }
    
    // usage
    public MyClass
    {
    	[MyCustom]
    	public string MyProperty
    	{
    		get
    		{
    			return this.AttributeToString<MyCustomAttribute>("MyProperty");
    		}
    	}
    }
