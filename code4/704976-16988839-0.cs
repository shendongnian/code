    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var props = doc.DocumentNode.Descendants("meta")
                .ToDictionary( m => m.Attributes["property"].Value,
                                m => m.Attributes["content"].Value);
    Console.WriteLine(props["og:image"]);
