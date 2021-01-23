    string[] domains = { "domain1.com", "domain2.com",...., "domain100.com" };
    var client = new HttpClient();
    var tasks = domains.Select(domain => client.GetAsync(domain)
                                   .ContinueWith(task =>
                                   {
                                       HttpResponseMessage response = task.Result;
                                       var headers = response.Headers;
                                       //Write to log file
                                   }));
    await Task.WhenAll(tasks);
