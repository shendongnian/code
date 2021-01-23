	string[] lines = System.IO.File.ReadAllLines("File.txt");
	int skip = 3;
	string word = "foo";
	string pattern = string.Format("\\b{0}\\b", word);
	for (int i = 0; i < lines.Count(); i++)
	{
		var match = System.Text.RegularExpressions.Regex.IsMatch(lines[i], pattern);
		System.Diagnostics.Debug.Print(string.Format("Line {0}: {1}", Array.IndexOf(lines, lines[i], i) + 1, match));
		if (match) i += skip;
		
	}
