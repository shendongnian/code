    const string url = "http://feeds.feedburner.com/TechCrunch";
    var doc = XDocument.Load(url);
    var items = doc.Descendants("item");
    XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";
    foreach (var item in items)
    {
        var encodedContent = (string)item.Element(nsContent + "encoded");
        var decodedContent = System.Net.WebUtility.HtmlDecode(encodedContent);
        var html = new HtmlDocument();
        html.LoadHtml(decodedContent);
        var ps = html.DocumentNode.Descendants("p");
        foreach (var p in ps)
        {
            var textContent = p.InnerText;
            // do something with textContent
        }
    }
