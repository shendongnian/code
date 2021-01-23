	public string SubstituteStandardValues(string exp)
	{
        var matches = Regex.Matches(exp, @"\$[a-z]+\$", RegexOptions.IgnoreCase);
		foreach (Match match in matches)
		{
			// replace logic here...
		}
		return exp;
	}
