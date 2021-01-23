    public static class StringExtensions
    {
    	public static string NullIfEmpty(this string theString)
    	{
    		if (string.IsNullOrEmpty(theString))
    		{
    			return null;
    		}
    		
    		return theString;
    	}
    }
