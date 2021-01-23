    for (int i = 0; i < 1; i++)
            {
                foreach (DataRow dtRow in urlTable.Rows)
                {
                    Thread thread = new Thread(MasterCrawlerClass.MasterCrawlBegin);
                    thread.Start(dtRow);
                }
            }
    
     public static void MasterCrawlBegin(object data)
        {
            var dtRow = (DataRow)data;
    
            if (dtRow.ItemArray[0].ToString().Contains("$"))
            {
                linkGrabberwDates(dtRow.ItemArray[0].ToString(), "www");
            }
            else
            {
                NoDatesCarCrawler(dtRow.ItemArray[0].ToString(), "www");
            }
    
        }
