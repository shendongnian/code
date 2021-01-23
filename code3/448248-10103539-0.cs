    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var list = doc.DocumentNode.Descendants("ul")
        .Select(n => n.Descendants("li").Select(li => li.InnerText).ToList())
        .ToList();
