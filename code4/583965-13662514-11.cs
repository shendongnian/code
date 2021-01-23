    public List<string> getAllLinks(string webAddress)
    {
        HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        HtmlDocument newdoc=web.Load(webAddress);
        return doc.DocumentNode.SelectNodes("//a[@href]")
                  .Where(y=>y.Attributes["href"].Value.StartsWith("http"))
                  .Select(x=>x.Attributes["href"].Value)
                  .ToList<string>();
    }
