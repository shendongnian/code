    public static IList<string> GetSplitStrings(string input)
    {
        IList<string> splitStrings = new List<string>();
        var counter = 0;
    
        var sb = new StringBuilder();
        foreach (var character in input)
        { 
    	if (character.Equals('"') || character.Equals('<') || character.Equals('>'))
    	{
    	    counter++;
    	}
    
    	if ((character.Equals(' ') && counter == 0) || (counter == 2))
    	{
    	    if (sb.ToString().Equals("") == false)
    	    {
    		if (character.Equals('"') || character.Equals('>'))
    		{
    		    sb.Append(character);
    		}
    		splitStrings.Add(sb.ToString());
    	    }
    	    sb.Clear();
    	    counter = 0;
    	}
    	else
    	{
    	    sb.Append(character);
    	}
        }
    
        return splitStrings;
    }
