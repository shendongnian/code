    public static class FizzBuzzUtils
    {
    	private static List<KeyValuePair<int, string>> map = new List<KeyValuePair<int, string>> {
    		new KeyValuePair<int, string>(3, "Fizz"),
    		new KeyValuePair<int, string>(5, "Buzz")
    	};
    
    	public static string GetValue(int i)
    	{
    		var matches = map.Where(kvp => i % kvp.Key == 0)
    			.Select(kvp => kvp.Value)
    			.ToArray();
    		return matches.Length > 0 ? string.Join(string.Empty, matches) : i.ToString();
    	}
    
    	public static IEnumerable<string> Range(int start, int count)
    	{
    		return Enumerable.Range(start, count)
    			.Select(i => GetValue(i));
    	}
    }
