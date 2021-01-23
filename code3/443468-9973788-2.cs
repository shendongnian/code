	static Regex rx = new Regex("(?<=^tcm:)[0-9]+", RegexOptions.Compiled);
	public string ReplaceOneWith(string source, string target)
	{
		return rx.Replace(source, new MatchEvaluator((Match m) =>
		{
			var targetMatch = rx.Match(target);
			if (targetMatch.Success)
				return targetMatch.Value;
			return m.Value;	//don't replace if no match
		}));
	}
