    // Check for "[^"]*" first to filter out any quoted strings
    // Assign any matches of AND to the "AND" group
    // Assign any matches of OR to the "OR" group
    const string pattern = @"(""[^""]*"")|\s+((?<AND>AND)|(?<OR>OR))\s+";
    
    public static string FixUp(string s)
    {
    	return Regex.Replace(s, pattern, ReplaceANDsAndORs, RegexOptions.IgnoreCase);
    }
    
    public static string ReplaceANDsAndORs(Match m)
    {
    	if (m.Groups["AND"].Length > 0)
    	{
    		return "AND";
    	}
    	else if (m.Groups["OR"].Length > 0)
    	{
    		return " ";
    	}
    	else
    	{
    		return m.Value;
    	}
    }
