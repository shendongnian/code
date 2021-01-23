    public static List<string> CrawlWithDepth(string url, int depth)
    {
        var ret = new List<string>();
        var linksFromPage = GetLinks(url);
        ret.AddRange(linksFromPage);
        if (depth > 0)
        {
            foreach (var childLink in linksFromPage)
            {
                var childCrawlResults = CrawlWithDepth(childLink, depth - 1);
                ret.AddRange(childCrawlResults);
            }
        }
    }
    
    private static List<string> GetLinks(string url)
    {
        var ret = new List<string>();
        foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            var href = link.Attributes["href"].Value;
            ret.Add(href);
        }
        return ret;
    }
