    private string Prepare(string input)
    {
    	StringBuilder output = new StringBuilder();
    	char[] chars = input.ToCharArray();
    	for (int i = 0; i < chars.Length; i++)
    	{
    		if (chars[i] == '-')
    		{
    			if (i > 0)
    			{
    				output.Append(chars[i - 1]);
    			}
    			if (++i < chars.Length)
    			{
    				output.Append(chars[i])
    			}
    			else
    			{
    				break;
    			}
    		}
    	}
    	return output.ToString();
    }
