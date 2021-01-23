	public static string DecreaseName( string name, string exclusions )
	{
		if (string.IsNullOrEmpty(name))
		{
			return name;
		}
		// Split the problem into sections (reverse order)
		List<StringBuilder> sections = new List<StringBuilder>();
		StringBuilder result = new StringBuilder(name.Length);
		bool isNumeric = char.IsNumber(name[0]);
		StringBuilder sb = new StringBuilder();
		sections.Add(sb);
		foreach (char c in name)
		{
			// If we change between alpha and number, start new string.
			if (char.IsNumber(c) != isNumeric)
			{
				isNumeric = char.IsNumber(c);
				sb = new StringBuilder();
				sections.Insert(0, sb);
			}
			sb.Append(c);
		}
		// Now process each section
		bool cascadeToNext = true;
		foreach (StringBuilder section in sections)
		{
			if (cascadeToNext)
			{
                result.Insert(0, DecrementString(section, exclusions, out cascadeToNext));
			}
			else
			{
				result.Insert(0, section);
			}
		}
		return result.ToString().Replace(" ", "");
	}
