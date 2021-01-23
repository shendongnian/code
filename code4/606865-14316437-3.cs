    // This is the query expression.    
    string query = "Xbox Live Games";
    
    // Create a Bing container.    
    string rootUrl = "https://api.datamarket.azure.com/Bing/Search";
    
    var bingContainer = new Bing.BingSearchContainer(new Uri(rootUrl));
    
    // The market to use.    
    string market = "en-us";
    
    // Get news for science and technology.    
    string newsCat = "rt_ScienceAndTechnology";
    
    // Configure bingContainer to use your credentials.    
    bingContainer.Credentials = new NetworkCredential(AccountKey, AccountKey);
    
    // Build the query, limiting to 10 results.    
    var newsQuery =
    
    bingContainer.News(query, null, market, null, null, null, null, newsCat, null);
    
    newsQuery = newsQuery.AddQueryOption("$top", 10);
    
    // Run the query and display the results.
    
    var newsResults = newsQuery.Execute();
    
    foreach (var result in newsResults)
    
    {
    
    Console.WriteLine("{0}-{1}\n\t{2}",
    
    result.Source, result.Title, result.Description);
    
    }
