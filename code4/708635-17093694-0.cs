	public static string DisplayCamelCaseString(string camelCase)
	{
		List<char> chars = new List<char>();
		chars.Add(camelCase[0]);
		foreach(char c in camelCase.Skip(1))
		{
			if (char.IsUpper(c))
			{
				chars.Add(' ');
				chars.Add(char.ToLower(c));
			}
			else
				chars.Add(c);
		}
		
		return new string(chars.ToArray());
	}
