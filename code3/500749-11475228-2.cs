    void PrintWebsiteTitle(string page)
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(page);
        Console.WriteLine(doc.DocumentNode.Descendants("title").First().InnerText);
    }
