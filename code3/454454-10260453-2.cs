    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml("....");
  
    var inputs = doc.DocumentNode.Descendants("input")
        .Where(n => n.Attributes["name"]!=null && n.Attributes["name"].Value == "sometext")
        .ToArray();
