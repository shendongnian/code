     WebClient aClient = new WebClient();
     WebHeaderCollection collection = new WebHeaderCollection();
     collection[HttpRequestHeader.Range] = "bytes=0-0";
     aClient.Headers = collection; 
     aClient.DownloadStringAsync(new Uri("URI GOES HERE"));
