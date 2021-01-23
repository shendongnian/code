    public void LoadSiteContent_A(string url, Action<string> onCompletion)
    {
            //create a new WebClient object
            WebClient clientC = new WebClient();
            clientC.DownloadStringCompleted += (s,e) =>
            {
                 onCompletion(e.Result);
            };
            clientC.DownloadStringAsync(new Uri(url));
    }
