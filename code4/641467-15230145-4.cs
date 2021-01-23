    using HtmlAgilityPack;
    static IEnumerable<string> WordsInHtml(string text)
    {
        var splitter = new Regex(@"[^\p{L}]*\p{Z}[^\p{L}]*");
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(text);
    
        foreach(HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
        {
            foreach(var word in splitter.Split(node.InnerText)
            {
                yield return word;
            }
        }
    }
