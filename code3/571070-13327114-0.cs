    Match match = Regex.Match(responseFromServer, m, RegexOptions.IgnoreCase);
	if (match.Success)
	{
		listBox1.Items.Add(match.Groups[2]Value.ToString());
	}
	if (listBox1.Items.Count % 50 == 0)
	{
		n++;
	}
