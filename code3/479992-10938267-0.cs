    Dictionary<string, Type> Types = new Dictionary<string, Type>
    {
        { "Trial", typeof(Trials) },
        { "Coverage", typeof(Coverage) },
    };
    void Crawl()
    {
        string itemType = "Trial";
        CrawlerBase crawler = (CrawlerBase)Activator.CreateInstance(Types[itemType]);
        crawler.Process("url");
    }
