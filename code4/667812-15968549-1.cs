    public static class StringExtensions
    {
    	public static string Stuff(this string input, int start, int length, string replaceWith)
    	{
    		return input.Remove(start, length).Insert(start, replaceWith);
    	}
    }
