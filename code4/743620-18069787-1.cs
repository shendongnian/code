    public static string Concat(string str0, string str1)
    {
    	if (string.IsNullOrEmpty(str0))
    	{
    		if (string.IsNullOrEmpty(str1))
    		{
    			return string.Empty;
    		}
    		return str1;
    	}
    	else
    	{
    		if (string.IsNullOrEmpty(str1))
    		{
    			return str0;
    		}
    		int length = str0.Length;
    		string text = string.FastAllocateString(length + str1.Length);
    		string.FillStringChecked(text, 0, str0);
    		string.FillStringChecked(text, length, str1);
    		return text;
    	}
    }
