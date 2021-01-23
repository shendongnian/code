    public void FetchEntities(
        Action<List<Entity>> resultCallback, 
        Action<string> errorCallback)
    {
        List<Entity> myList = new List<Entity>();
        string url = "<myUrl>";
        string response = String.Empty;
        client = new WebClient();
        client.DownloadStringCompleted += (sender, e) =>
        {
            response = e.Result;
            // parse response
            // extract content and generate entities
            // <---- I am currently filling list here
            
            if (response == null)
            {
                if (errorCallback != null)
                    errorCallback("Ooops, something bad happened");
            }
            else
            {
                if (callback != null)
                    callback(myList);
            }
        };
        client.DownloadStringAsync(new Uri(url));
    }
