    public static class StringExtensions
    {
    	public static string TruncateTo(this string str, int maxCharsCount)
    	{
    		if (str.Length > maxCharsCount)
    			return str.Substring(0, maxCharsCount);
    		return str;
    	}
    }
