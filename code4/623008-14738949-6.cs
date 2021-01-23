    public static void ParseName(LXRecord record, string value)
    {
    	int tokenIndex = value.IndexOf(Tokens.TOKEN_SPLITTER);
    	if (tokenIndex < 1 || tokenIndex == value.Length - 1) //no last name and first name?
    	{
    		record.LastName = value;
    	}
    	else
    	{
    		record.LastName = value.Substring(0, tokenIndex);
    		record.FirstName = value.Substring(tokenIndex + 1);
    	}
    }
