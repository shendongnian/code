    void Main()
    {
    	dynamic config = new ExpandoObject();
    	config.FavoriteColor = ConsoleColor.Blue;
    	config.FavoriteNumber = 8;
    	Console.WriteLine(config.FavoriteColor);
    	Console.WriteLine(config.FavoriteNumber);
    	
    	var nvc = ((IDictionary<string, object>) config).ToNameValueCollection();
    	Console.WriteLine(nvc.Get("FavoriteColor"));
    	Console.WriteLine(nvc["FavoriteNumber"]);
    	Console.WriteLine(nvc.Count);
    }
    
    public static class Extensions
    {
    	public static NameValueCollection ToNameValueCollection<TKey, TValue>(this IDictionary<TKey, TValue> dict)
    	{
    		var nvc = new NameValueCollection();
    		foreach(var pair in dict)
    		{
    			string value = pair.Value == null ? null : value = pair.Value.ToString();
    			nvc.Add(pair.Key.ToString(), value);
    		}
    	
    		return nvc;
    	}
    
    }
