    public static class StringExtensions
    {
    	public static string RemoveStrings(this string str, params string[] strsToRemove)
    	{
    		var builder = new StringBuilder(str);
    		strsToRemove.ToList().ForEach(v => builder.Replace(v, ""));
    		return builder.ToString();
    	}
    }
