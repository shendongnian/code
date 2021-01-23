        using( var WCC = new WebSiteCrawlerClass() )
        {
            if (drow.ItemArray[0].ToString().Contains("$"))
            {
                WCC.linkGrabberwDates(drow.ItemArray[0].ToString(), "www");
            }
            else
            {
                WCC.NoDatesCarCrawler(drow.ItemArray[0].ToString(), "www");
            }
        }
