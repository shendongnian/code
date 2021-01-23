    public static string Convert(string input, bool firstIsUpper, bool restIsUpper)
    {
    	string firstLetter = input.Substring(0, 1);
    	firstLetter = firstIsUpper ? firstLetter.ToUpper() : firstLetter.ToLower();
    	string rest = input.Substring(1);
    	rest = restIsUpper ? rest.ToUpper() : rest.ToLower();
    	return firstLetter + rest;
    }
    
    public static string Replace(string input, Dictionary<string, string> valueMap)
    {
    	var ms = Regex.Matches(input, "{(\\w+?)}");
    	int i = 0;
    	var sb = new StringBuilder();
    	for (int j = 0; j < ms.Count; j++)
    	{
    		string pattern = ms[j].Groups[1].Value;
    		string key = pattern.ToLower();
    		bool firstIsUpper = char.IsUpper(pattern[0]);
    		bool restIsUpper = char.IsUpper(pattern[1]);
    		sb.Append(input.Substring(i, ms[j].Index - i));
    		sb.Append(Convert(valueMap[key], firstIsUpper, restIsUpper));
    		i = ms[j].Index + ms[j].Length;
    	}
    
    	return sb.ToString();
    }
    
    public static void DoStuff()
    {
    	Console.WriteLine(Replace("--- {aAA} --- {AAA} --- {Aaa}", new Dictionary<string,string> {{"aaa", "replacement"}}));
    }
    
