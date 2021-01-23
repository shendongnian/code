    public static class StringExtensions
    {
    	public static bool Is<T>(this string s)
    	{
    		if (typeof(T) == typeof(int))
    		{
    			int tmp;
    			return int.TryParse(s, out tmp);
    		}
    
    		if (typeof(T) == typeof(long))
    		{
    			long tmp;
    			return long.TryParse(s, out tmp);
    		}
    		...
    
    		return false;
    	}
    }
