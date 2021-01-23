    using (var client = new WebClient())
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(client.DownloadString("http://www.xul.fr/en-xml-rss.html"));
        var rssLinks = doc.DocumentNode.Descendants("link")
            .Where(n => n.Attributes["type"] != null && n.Attributes["type"].Value == "application/rss+xml")
            .Select(n => n.Attributes["href"].Value)
            .ToArray();
    }
