    public string createPermalink(string text)
    {
    	text = text.ToLower();
    	StringBuilder sb = new StringBuilder(text.Length);
    	
    	// We want to skip the first hyphenable characters and go to the "meat" of the string
    	bool lastHyphen = true;
    	
    	// You can enumerate directly a string
    	foreach (char c in text)
    	{
    		if (char.IsLetterOrDigit(c))
    		{
    			sb.Append(c);
    			lastHyphen = false;
    		}		
    		else if (!lastHyphen)
    		{
    			// We use lastHyphen to not put two hyphens consecutively
    			sb.Append('-');
    			lastHyphen = true;
    		}
    		
    		if (sb.Length == 200)
    		{
    			break;
    		}
    	}
    	
    	// Remove the last hyphen
    	if (sb.Length > 0 && sb[sb.Length - 1] == '-')
    	{
    		sb.Length--;
    	}
    	return sb.ToString();
    }
