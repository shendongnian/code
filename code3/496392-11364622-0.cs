    static void Main(string[] args)
    {
    	string str = "a = 23, b = 432, f = 321, gfs = 413, d = 42, k = 4242, t = 4314";
    	Dictionary<string,string> dictionary = ConstructDictionary(str);
    	// Now you can find what you want in your dictionary
    }
    
    private static Dictionary<string,string> ConstructDictionary(string str)
    {
    	string[] pairs = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); // this will give you all the pairs X = Y
    	Dictionary<string, string> dictionary = new Dictionary<string, string>();
    	foreach (string pair in pairs)
        {
    		string[] keyValue = pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries); // this will create an array of size 2 where 
            array[0] = key and array[1] = value;
    		string key = keyValue[0].Trim();
    		string value = keyValue[1].Trim();
    		if (!dictionary.ContainsKey(key))
    		{
    			dictionary.Add(key, value);
    		}
    	}
    	return dictionary;
    }
