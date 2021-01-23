	var points = new List<string>();
	var intervals = new List<string>();
	foreach (Match match in Regex.Matches(input, @"(\d+[MWD])(\d+)"))
	{
		points.Add(match.Groups[1].Value);
		intervals.Add(match.Groups[2].Value);
	}
	
