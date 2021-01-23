    CommandLine.EnableExceptionHandling();            
    CommandLine.DisplayGoogleSampleHeader("PlusService API");     
    
    // Create the service.             
    var objService= new PlusService();
    objService.Key = ""; //put in user key.
    var acts = objService.Activities.Search();
    acts.Query = "super cool";
    acts.MaxResults = 10;
    var searchResults = acts.Fetch();
    if (searchResults.Items != null)
    {
       foreach (Activity feed in searchResults.Items)
       {
          //extract any property of uer interest
          CommandLine.WriteResult(feed.Title, feed.Actor);
       }
    }
