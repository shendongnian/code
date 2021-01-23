	private List<string> getEmAll(string search)
	{
		var matches = (new Regex(@"Your Expression Here")).Match(search);
		var ret = new List<string>();
		while (matches.Success)
		{
			ret.Add(matches.Value);
			ret.AddRange(getEmAll(matches.Value));
			matches = matches.NextMatch();
		}
		return ret;
	}
    
    ...
    getEmAll("GetValue(GetValue(GetValue(1 + 2) * GetValue(3 * 4)) / GetValue(GetValue(5 * 6) / 7) / 8)");
