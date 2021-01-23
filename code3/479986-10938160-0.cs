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
       crawler.Process(item.URL);
}
