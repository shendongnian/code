    var client = new MyWebClient(TimeoutInSeconds);
    
    client.DownloadDataAsync(new Uri(par.Base_url))
        .ContinueWith(t =>
        {
            client.Dispose();
    
            var res = t.Result;
    
            //code that checks res
        }
    }  
