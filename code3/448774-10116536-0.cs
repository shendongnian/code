    int ActiveThreads = 0;
    var options = new ParallelOptions(); 
    options.MaxDegreeOfParallelism = 9; 
    Parallel.ForEach(urlTable.AsEnumerable(),options,drow => 
    {
      int x = Interlocked.Increment(ref ActiveThreads);
      Console.WriteLine("Active Thread #: " + x); 
      try
      {
        using (var WCC = new MasterCrawlerClass()) 
        { 
          WCC.MasterCrawlBegin(drow); 
        }
      }
      finally
      {
        Interlocked.Decrement(ref ActiveThreads);
        Console.WriteLine("Done Crawling a datarow"); 
      } 
    }); 
