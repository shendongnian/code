    // Custom attribute might be something like this
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BrandedAttribute : Attribute
    {
    	private readonly ResourceManager _rm;
    	private readonly string _key;
    
    	public BrandedAttribute(string resourceKey)
    	{
    		_rm = new ResourceManager("brand", typeof(BrandedAttribute).Assembly);
    		_key = resourceKey;
    	}
    
    	public override string BrandText
    	{
    		get
    		{
    			// do what you need to do in order to generate the right text
    			return brandA_resource.ResourceManager.GetString(_key); 	
    		}
    	}
    
    	public override string ToString()
    	{
    		return DisplayName;
    	}
    }
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
        // I chose to do this via ToString() just for simplicity sake
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
