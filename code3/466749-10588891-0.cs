    HashSet<string> visitedPages = new HashSet<string>();
    for (int i = 0; i < webSites.Count(); i++)
    {
        string page = webSites[i];
        if(!visitedPages.Contains(page))
        {
            visitedPages.Add(page);
            webCrawler(page, levels - 1);
        }
    }
