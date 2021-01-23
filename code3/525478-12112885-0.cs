	HtmlWeb hwObject = new HtmlWeb();
	HtmlDocument htmldocObject = hwObject.Load("http://whois.domaintools.com/94.100.179.159");
	foreach (HtmlNode link in htmldocObject.DocumentNode.SelectNodes("//meta"))
	{
		Console.WriteLine("-META-");
		var attribDump=link.Attributes.Select(a=>a.Name+" : "+a.Value);
		foreach (var x in attribDump)
		{
			Console.WriteLine(x);
		}
	}
