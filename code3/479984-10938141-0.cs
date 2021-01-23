    foreach (var item in result)
    {
        CrawlerBase crawler = null;
        
        switch (item.Type)
        {
            case "Trials":
                crawler = new Trials(); 
                break;
            case "Coverage":
                crawler = new Coverage();
                break;
            default:
                break;
        }
        
        if(crawler != null)
            crawler.Process(item.URL);
    }
