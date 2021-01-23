	public static string WrapText(string text, int width, bool overflow)
	{
		StringBuilder result = new StringBuilder();
		int index = 0;
		int column = 0;
		while (index < text.Length)
		{
			int spaceIndex = text.IndexOfAny(new[] { ' ', '\t', '\r', '\n' }, index);
			if (spaceIndex == -1)
			{
				break;
			}
			else if (spaceIndex == index)
			{
				index++;
			}
			else
			{
				AddWord(text.Substring(index, spaceIndex - index));
				index = spaceIndex + 1;
			}
		}
		if (index < text.Length) AddWord(text.Substring(index));
		void AddWord(string word)
		{
			if (!overflow && word.Length > width)
			{
				int wordIndex = 0;
				while (wordIndex < word.Length)
				{
					string subWord = word.Substring(wordIndex, Math.Min(width, word.Length - wordIndex));
					AddWord(subWord);
					wordIndex += subWord.Length;
				}
			}
			else
			{
				if (column + word.Length >= width)
				{
					if (column > 0)
					{
						result.AppendLine();
						column = 0;
					}
				}
				else if (column > 0)
				{
					result.Append(" ");
					column++;
				}
				result.Append(word);
				column += word.Length;
			}
		}
		return result.ToString();
	}
