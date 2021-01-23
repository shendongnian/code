    public class LocalizedEnumAttribute : DescriptionAttribute
    {
    	private PropertyInfo _nameProperty;
    	private Type _resourceType;
    
    	public LocalizedEnumAttribute(string displayNameKey)
    		: base(displayNameKey)
    	{
    	}
    
    	public Type NameResourceType
    	{
    		get
    		{
    			return _resourceType;
    		}
    		set
    		{
    			_resourceType = value;
    
    			_nameProperty = _resourceType.GetProperty(this.Description, BindingFlags.Static | BindingFlags.Public);
    		}
    	}
    
    	public override string Description
    	{
    		get
    		{
    			//check if nameProperty is null and return original display name value
    			if (_nameProperty == null)
    			{
    				return base.Description;
    			}
    
    			return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
    		}
    	}
    }
    
    I also have a `EnumHelper` class to use on my projects to create dictionaries of enums values localized:
    
    public static class EnumHelper
    {
    	// get description data annotation using RESX files when it has
    	public static string GetDescription(Enum @enum)
    	{
    		if (@enum == null)
    			return null;
    
    		string description = @enum.ToString();
    
    		try
    		{
    			FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
    
    			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
    			if (attributes.Any())
    				description = attributes[0].Description;
    		}
    		catch
    		{
    		}
    
    		return description;
    	}
    
    	public static IDictionary<TKey, string> GetEnumDictionary<T, TKey>()
    		where T : struct 
    	{
    		Type t = typeof (T);
    
    		if (!t.IsEnum)
    			throw new InvalidOperationException("The generic type T must be an Enum type.");
    		
    		var result = new Dictionary<TKey, string>();
    
    		foreach (Enum r in Enum.GetValues(t))
    		{
    			var k = Convert.ChangeType(r, typeof(TKey));
    
    			var value = (TKey)k;
    
    			result.Add(value, r.GetDescription());
    		}
    
    		return result;
    	}
    }
    
    public static class EnumExtensions
    {
    	public static string GetDescription(this Enum @enum)
    	{
    		return EnumHelper.GetDescription(@enum);
    	}
    }
