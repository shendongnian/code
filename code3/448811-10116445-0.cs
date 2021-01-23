    int ActiveThreads = 0;
    int ActiveCrawls = 0;
    var semaphore = new SemaphoreSlim(3, 3); 
    Parallel.ForEach(urlTable.AsEnumerable(), drow => 
      { 
        int x = Interlocked.Increment(ref ActiveThreads);
        Console.WriteLine("Active Thread #: " + x); 
        semaphore.Wait();
        int y = Interlocked.Increment(ref ActiveCrawls);
        Console.WriteLine("Active Crawl #: " + y); 
        try
        {
          using (var WCC = new MasterCrawlerClass()) 
          { 
            WCC.MasterCrawlBegin(drow);
          }
        }
        finally
        {
          Interlocked.Decrement(ref ActiveCrawls);
          semaphore.Release();
          Interlocked.Decrement(ref ActiveThreads);
          Console.WriteLine("Done Crawling a datarow"); 
        }
      } 
    }); 
