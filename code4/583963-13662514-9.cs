    public string getContent(string webAddress)
    {
        HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        HtmlDocument doc=web.Load(webAddress);
        return string.Join(" ",doc.DocumentNode.Descendants().Select(x=>x.InnerText));
    }
