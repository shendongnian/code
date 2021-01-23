	List<string> elements = new List<string>();
	var pattern = @"(?:High|Low)\s*:\s*(?<num>-?\d+)";
	foreach (HtmlNode element in htmlDoc.DocumentNode.SelectNodes("//br"))
	{
		foreach(Match mc in Regex.Matches(element.NextSibling.InnerText, pattern))
		{
			elements.Add(mc.Groups["num"].ToString());
		}
	}
