    public static class ExtensionMethods
    {
    	public static IEnumerable<KeyValuePair<string, string>> Each(this FormCollection collection)
    	{
    		foreach (string key in collection.AllKeys)
    		{
    			yield return new KeyValuePair<string, string>(key, collection[key]);
    		}
    	}
    }
