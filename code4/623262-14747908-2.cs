    var httpClient = new HttpClient();
    var tasks = urls.Select(url => httpClient.GetStringAsync(url)
                            .ContinueWith(task =>
                            {
                                string response = task.Result;
                                return ConvertToStrongType(response);
                            }));
     Task.WaitAll(tasks.ToArray());
     var results = tasks.Select(t => t.Result);
