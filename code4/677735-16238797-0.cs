    public static class StringExtensions
    {
    	public static string Truncate(this string text, int length)
    	{
    		var sb = new StringBuilder(text);
    		
    		var i = Math.Min(length, sb.Length);
    		if ((sb.Length > length) && !char.IsWhiteSpace(sb[i]))
    		{
    			while ((--i >= 0) && !char.IsWhiteSpace(sb[i]))
    			{
    			}
    		}
    		
    		if (i > 0)
    		{
    			while ((--i >= 0) && char.IsWhiteSpace(sb[i]))
    			{
    			}
    		}
    		
    		return sb.ToString(0, i + 1);
    	}
    }
