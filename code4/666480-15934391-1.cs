    public static class ExtensionMethods
    {
    	public static T As<T>(this string input, T fallback = default(T), 
                              IFormatProvider provider = null)
    	{
    		var type = Nullable.GetUnderlyingType(typeof(T));
    		if (type == null)
    			type = typeof(T);
    		T result;
    		try
    		{
    			result = (T)Convert.ChangeType(input, type, provider);
    		}
    		catch(Exception)
    		{
    			result = fallback;
    		}
    		return result;
    	}
    }
