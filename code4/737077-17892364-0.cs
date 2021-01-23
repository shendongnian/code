    private int StringMatches(string searchMe, string[] keys)
    {
    	System.Text.RegularExpressions.Regex expression = new System.Text.RegularExpressions.Regex(string.Join("|", keys), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    	return expression.Matches(searchMe).Count;
    }
