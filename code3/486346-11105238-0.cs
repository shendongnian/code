    static string ReplaceCaseInsensitive(string Text, string Find, string Replace)
    {
    	char[] NewText = Text.ToCharArray();
    	int ReplaceLength = Math.Min(Find.Length, Replace.Length);
    
    	int LastIndex = -1;
    	while (true)
    	{
    		LastIndex = Text.IndexOf(Find, LastIndex + 1, StringComparison.CurrentCultureIgnoreCase);
    
    		if (LastIndex == -1)
    		{
    			break;
    		}
    		else
    		{
    			for (int i = 0; i < ReplaceLength; i++)
    			{
    				if (char.IsUpper(Text[i + LastIndex])) 
    					NewText[i + LastIndex] = char.ToUpper(Replace[i]);
    				else
    					NewText[i + LastIndex] = char.ToLower(Replace[i]);
    			}
    		}
    	}
    
    	return new string(NewText);
    }
