	public static List<Mistake> OptimalStringAlignmentDistance(
	  string word, string correctedWord,
	  bool transposition = true,
	  int substitutionCost = 1,
	  int insertionCost = 1,
	  int deletionCost = 1,
	  int transpositionCost = 1)
	{
		int w_length = word.Length;
		int cw_length = correctedWord.Length;
		var d = new KeyValuePair<int, CharMistakeType>[w_length + 1, cw_length + 1];
		var result = new List<Mistake>(Math.Max(w_length, cw_length));
		if (w_length == 0)
		{
			for (int i = 0; i < cw_length; i++)
				result.Add(new Mistake(i, CharMistakeType.Insertion));
			return result;
		}
		for (int i = 0; i <= w_length; i++)
			d[i, 0] = new KeyValuePair<int, CharMistakeType>(i, CharMistakeType.None);
		for (int j = 0; j <= cw_length; j++)
			d[0, j] = new KeyValuePair<int, CharMistakeType>(j, CharMistakeType.None);
		for (int i = 1; i <= w_length; i++)
		{
			for (int j = 1; j <= cw_length; j++)
			{
				bool equal = correctedWord[j - 1] == word[i - 1];
				int delCost = d[i - 1, j].Key + deletionCost;
				int insCost = d[i, j - 1].Key + insertionCost;
				int subCost = d[i - 1, j - 1].Key;
				if (!equal)
					subCost += substitutionCost;
				int transCost = int.MaxValue;
				if (transposition && i > 1 && j > 1 && word[i - 1] == correctedWord[j - 2] && word[i - 2] == correctedWord[j - 1])
				{
					transCost = d[i - 2, j - 2].Key;
					if (!equal)
						transCost += transpositionCost;
				}
				int min = delCost;
				CharMistakeType mistakeType = CharMistakeType.Deletion;
				if (insCost < min)
				{
					min = insCost;
					mistakeType = CharMistakeType.Insertion;
				}
				if (subCost < min)
				{
					min = subCost;
					mistakeType = equal ? CharMistakeType.None : CharMistakeType.Substitution;
				}
				if (transCost < min)
				{
					min = transCost;
					mistakeType = CharMistakeType.Transposition;
				}
				d[i, j] = new KeyValuePair<int, CharMistakeType>(min, mistakeType);
			}
		}
		int w_ind = w_length;
		int cw_ind = cw_length;
		while (w_ind >= 0 && cw_ind >= 0)
		{
			switch (d[w_ind, cw_ind].Value)
			{
				case CharMistakeType.None:
					w_ind--;
					cw_ind--;
					break;
				case CharMistakeType.Substitution:
					result.Add(new Mistake(cw_ind - 1, CharMistakeType.Substitution));
					w_ind--;
					cw_ind--;
					break;
				case CharMistakeType.Deletion:
					result.Add(new Mistake(cw_ind, CharMistakeType.Deletion));
					w_ind--;
					break;
				case CharMistakeType.Insertion:
					result.Add(new Mistake(cw_ind - 1, CharMistakeType.Insertion));
					cw_ind--;
					break;
				case CharMistakeType.Transposition:
					result.Add(new Mistake(cw_ind - 2, CharMistakeType.Transposition));
					w_ind -= 2;
					cw_ind -= 2;
					break;
			}
		}
		if (d[w_length, cw_length].Key > result.Count)
		{
			int delMistakesCount = d[w_length, cw_length].Key - result.Count;
			for (int i = 0; i < delMistakesCount; i++)
				result.Add(new Mistake(0, CharMistakeType.Deletion));
		}
		result.Reverse();
		return result;
	}
	public struct Mistake
	{
		public int Position;
		public CharMistakeType Type;
		public Mistake(int position, CharMistakeType type)
		{
			Position = position;
			Type = type;
		}
		public override string ToString()
		{
			return Position + ", " + Type;
		}
	}
	public enum CharMistakeType
	{
		None,
		Substitution,
		Insertion,
		Deletion,
		Transposition
	}
