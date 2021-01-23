    public static class ExtensionMethods
    {
    	public static T As<T>(this string input, T fallback = default(T))
    	{
    		var type = Nullable.GetUnderlyingType(typeof(T));
    		if (type == null)
    			type = typeof(T);
    		T result;
    		try
    		{
    			result = (T)Convert.ChangeType(input, type);
    		}
    		catch(Exception)
    		{
    			result = fallback;
    		}
    		return result;
    	}
    }
