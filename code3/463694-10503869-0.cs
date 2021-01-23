    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var links =doc.DocumentNode
                  .Descendants("a")
                  .Select(n => n.Attributes["href"].Value).ToArray();
