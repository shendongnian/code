    var httpClient = new HttpClient();
    var result = urls.Select(url => httpClient.GetStringAsync(url)
                                 .ContinueWith(task =>
                                           {
                                                string response = task.Result;
                                                return ConvertToStrongType(response);
                                           }).Result); 
