    public static class ParameterExtensions
    {
    	public static DynamicParameters ConvertToDynamicParameters<T>(this T incoming)
    	{
    	  DynamicParameters dynamicParameters = new DynamicParameters();
    	  foreach (PropertyInfo property in incoming.GetType().GetProperties())
    	  {
    		object value = GetPropValue(incoming, property.Name);
    		if (value != null) dynamicParameters.Add(property.Name, value);
    	  }
    	  return dynamicParameters;
    	}
    
    	private static object GetPropValue(object src, string propName)
    	{
    	  return src.GetType().GetProperty(propName)?.GetValue(src, null);
    	}
    }
