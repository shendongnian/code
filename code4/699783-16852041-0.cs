    public static Nullable<TSource> TryParse<TSource>(this string input) where TSource : struct
    {
    	try
    	{
    		var result = Convert.ChangeType(input, typeof(TSource));
    		if (result != null)
    		{
    			return (TSource)result;
    		}
    		return null;
    	}
    	catch (Exception)
    	{
    		return null;
    	}
    }
