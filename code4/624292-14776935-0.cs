    public static class EnumExtensions
    {
    	public static string EnumToJson(this Type type)
    	{
    		if (!type.IsEnum)
    			throw new InvalidOperationException("enum expected");
    
    		var results =
    			Enum.GetValues(type).Cast<object>()
    				.ToDictionary(enumValue => enumValue.ToString(), enumValue => (int) enumValue);
    
    
    		return string.Format("{{ \"{0}\" : {1} }}", type.Name, Newtonsoft.Json.JsonConvert.SerializeObject(results));
    		
    	}
    }
