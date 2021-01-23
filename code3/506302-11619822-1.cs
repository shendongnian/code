    using (var wc = new WebClient())
    {
        XDocument xDoc = XDocument.Parse(wc.DownloadString("http://www.nyc.gov/apps/311/311Today.rss"));
        XNamespace content = XNamespace.Get("http://purl.org/rss/1.0/modules/content/");
        var items = xDoc.Descendants("item")
                .Select(i => new
                {
                    Title = i.Element("title").Value,
                    Date = DateTime.Parse(i.Element("pubDate").Value),
                    Desc = i.Element(content + "encoded").Value,
                })
                .ToArray();
    }
