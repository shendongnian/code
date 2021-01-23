    public List<Entity> FetchEntities()
    {
        List<Entity> myList = new List<Entity>();
        string url = "<myUrl>";
        string response = String.Empty;
        client = new WebClient();
        AutoResetEvent waitHandle = new AutoResetEvent(false);
        client.DownloadStringCompleted += (sender, e) =>
        {
            response = e.Result;
            // parse response
            // extract content and generate entities
            // <---- I am currently filling list here
            waitHandle.Set();
        };
        client.DownloadStringAsync(new Uri(url));
        waitHandle.WaitOne();
        return myList;
    }
