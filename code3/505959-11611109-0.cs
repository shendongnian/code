    static void Main(string[] args)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.Load("file.htm");
        var results = doc.DocumentNode
            .SelectNodes("//li[contains(@class, 'f')]")
            .Select(x => x.InnerHtml);
        foreach (string result in results)
        {
            Console.WriteLine(result);
        }
    }
