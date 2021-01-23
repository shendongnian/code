    static string Mask(string str)
    {
    	if (str.Length <= 4) return str;
    	Regex rgx = new Regex(@"(.*?)(\d{4})$");
    	string result = String.Empty;
    	if (rgx.IsMatch(str))
    	{
    		for (int i = 0; i < rgx.Matches(str)[0].Groups[1].Length; i++)
    			result += "*";
    		result += rgx.Matches(str)[0].Groups[2];
    		return result;
    	}
    	return str;
    }
