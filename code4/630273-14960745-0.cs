	public IEnumerable<string> GetPermutations(IEnumerable<string> possibleCombos, string delimiter)
	{
		var permutations = new Dictionary<int, List<string>>();
		var comboArray = possibleCombos.ToArray();
		var splitCharArr = new char[] { ',' };
		permutations[0] = new List<string>();
		permutations[0].AddRange(
			possibleCombos
			.First()
			.Split(splitCharArr)
			.Where(x => !string.IsNullOrEmpty(x.Trim()))
			.Select(x => x.Trim()));
		for (int i = 1; i < comboArray.Length; i++)
		{
			permutations[i] = new List<string>();
			foreach (var permutation in permutations[i - 1])
			{
				permutations[i].AddRange(
					comboArray[i].Split(splitCharArr)
					.Where(x => !string.IsNullOrEmpty(x.Trim()))
					.Select(x => string.Format("{0}{1}{2}", permutation, delimiter, x.Trim()))
					);
			}
		}
		return permutations[permutations.Keys.Max()];
	}
