    public static class TypeExtensions
    {
    	public static List<string> GetFieldsAndPropertiesAsString(this Type type)
    	{
    		return new List<string>(type.GetFieldsAsString().Union(type.GetPropertiesAsString()));
    	}
    
    	public static IEnumerable<string> GetFieldsAsString(this Type type)
    	{
    		// Modify BindingFlags to get what you want (instance only, private/public...)
    		foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
    		{
    			yield return field.Name;
    		}
    	}
    
    	public static IEnumerable<string> GetPropertiesAsString(this Type type)
    	{
    		// Modify BindingFlags to get what you want (instance only, private/public...)
    		foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    		{
    			yield return prop.Name;
    		}
    	}
    }
