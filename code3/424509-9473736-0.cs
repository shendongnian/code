    private string request(string json,
                           string url,
                           string Action<Exception, string> callback)
    {
        WebClient client = new WebClient();
        client.DownloadStringCompleted += (s, e) => 
            {
                // add better error handling than this!!!
                try
                {
                    callback(e.Error, e.Result);
                }
                catch (Exception exc)
                {
                    callback(exc, null);
                }
            };
        client.DownloadStringAsync(new Uri(url);    
    }
