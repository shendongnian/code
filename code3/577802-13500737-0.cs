    public Dictionary<char, int> Hist(string target)
		{
			return target.GroupBy(c => c)
				.ToDictionary(g => g.Key, (g => g.Count()));
		}
