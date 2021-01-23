    private string[] Prepare(string input)
    {
    	List<string> output = new List<string>();
    	char[] chars = input.ToCharArray();
    	for (int i = 0; i < chars.Length; i++)
    	{
    		if (chars[i] == '-')
    		{
    			string o = string.Empty;
    			if (i > 0)
    			{
    				o += chars[i - 1];
    			}
    			if (++i < chars.Length)
    			{
    				o += chars[i]
    			}
    			output.Add(o); 
    		}
    	}
    	return output.ToArray();
    }
