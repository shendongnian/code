    HtmlWeb siec = new HtmlWeb();
    HtmlAgilityPack.HtmlDocument htmldokument = siec.Load(@"https://www.google.pl/search?q=beer");
    List<string> list = new List<string>();
    
    if (htmldokument != null)
    {
    	foreach (HtmlNode text in htmldokument.DocumentNode.SelectNodes("//a[@class='l']"))
    	{
    		var href = text.GetAttributeValue("href", "");
    		list.Add(href);
    		Console.WriteLine(href);
    	}
    }
    Console.ReadKey();
