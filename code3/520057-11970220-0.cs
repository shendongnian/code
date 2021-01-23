    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(page);
    var text = doc.DocumentNode.Descendants("img")
        .Where(x => x.Attributes["class"].Value="????????")
        .Select(x=>x.InnerText)
        .ToArray();
	
