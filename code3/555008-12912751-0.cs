    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(content);
    foreach (var a in doc.DocumentNode.Descendants("a"))
    {
        a.Attributes["href"].Value = "http://a.com?url=" + HttpUtility.UrlEncode(a.Attributes["href"].Value);
    }
    var newContent = doc.DocumentNode.OuterHtml;
