    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml("....");
    var form = doc.DocumentNode.Descendants("form").First();
    //or
    var inputs = doc.DocumentNode.Descendants("input")
        .Where(n => n.Attributes["name"].Value == "sometext")
        .ToArray();
