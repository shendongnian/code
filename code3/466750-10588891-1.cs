    HashSet<string> visitedPages = new HashSet<string>();
    for (int i = 0; i < webSites.Count(); i++)
    {
        string page = webSites[i];
        if(visitedPages.Add(page)) //returns true if new page was added
        {
            webCrawler(page, levels - 1);
        }
    }
