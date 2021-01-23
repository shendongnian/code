	static Dictionary<string, List<int>> GetDuplicates2(string value)
	{
		var duplicates = new Dictionary<string, List<int>>();
		for (int i = 0; i < value.Length; i++)
		{
			for (int slength = 2; slength < (value.Length - i) / 2 + 2; slength++)
			{
				var littleString = value.Substring(i, slength);
	
				if (!duplicates.ContainsKey(littleString))
				{
					int nextOccurrence = value.IndexOf(littleString, i + slength - 1);
	
					if (nextOccurrence != -1)
					{
						var l = new List<int>();
						l.Add(i);
						l.Add(nextOccurrence);
						duplicates.Add(littleString, l);
	
						while ((nextOccurrence = value.IndexOf(littleString, nextOccurrence + slength - 1)) != -1)
						{
							duplicates[littleString].Add(nextOccurrence);
						}
					}
					else
					{
						break;
					}
				}
				else
				{
					break;
				}
			}
		}
	
		return duplicates;
	}
