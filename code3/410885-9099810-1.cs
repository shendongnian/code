    public static T? ParseOrNull<T>(this string value) where T : struct, IConvertible
    {
    	try
    	{	        
    		return (T)Convert.ChangeType(value, typeof(T));
    	}
    	catch (FormatException ex)
    	{
    		return null;
    	}
    }
