	static Dictionary<string, List<int>> GetLzwDuplicates(string value)
	{
		var duplicates = new Dictionary<string, List<int>>();
	
		if (value.Length > 1)
		{
			string match = value[0].ToString();
	
			for (int i = 1; i < value.Length; i++)
			{
				string nextMatch = match + value[i];
	
				if (duplicates.ContainsKey(nextMatch))
				{
					duplicates[nextMatch].Add(i - match.Length);
					if (i < value.Length - 1 && nextMatch.Substring(1) + value[i + 1] == nextMatch) // check for overlapping matches
					{
						duplicates[nextMatch].Add(i);
					}
					match = nextMatch;
				}
				else
				{
					var l = new List<int>();
					l.Add(i - match.Length);
					duplicates.Add(nextMatch, l);
					if (i == 1)
						match = nextMatch;
					else
						match = value[i].ToString();			
				}					
			}
		}
	
		foreach (var d in duplicates.ToList())
		{
			if (d.Value.Count == 1) duplicates.Remove(d.Key);
		}
	
		return duplicates;
	}
