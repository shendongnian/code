    private void CrawlWebsite(string url)
    {
        //Implementation here
    }
    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
        var options = new ParallelOptions() 
        { 
            MaxDegreeOfParallelism = 2000 
        };
        Parallel.ForEach(massiveListOfUrls, options, CrawlWebsite);
    }
