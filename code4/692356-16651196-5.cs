	string[] strings =
	{
		"ABC1100 - 2ppl",
		"ABC1300",
		"ABC 1300",
        "ABC-1300",
		"Managers Associates Only (ABC1100 - 2ppl)"
	};
	
	var reg = new Regex(@"ABC[\s,-]?[0-9]+");
	
	var systemNames = strings.Select(line => reg.Match(line).Value);
	
	systemNames.ToList().ForEach(Console.WriteLine);
