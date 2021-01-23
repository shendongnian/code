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
