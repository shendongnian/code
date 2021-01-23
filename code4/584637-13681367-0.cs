    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(@"<td><a href=""link"">");
    var links = doc.DocumentNode.SelectNodes("//a[@href]")
                .Select(a => a.Attributes["href"].Value)
                .ToList();
