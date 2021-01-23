    public static class StringExtension
    {
    	public static string Replace(this string baseValue, int start, int length, string oldValue, string newValue)
    	{
    		return baseValue.Substring(0, start) + baseValue.Substring(start, length).Replace(oldValue, newValue) + baseValue.Substring(start + length, baseValue.Length - (start + length));
    	}
    }
