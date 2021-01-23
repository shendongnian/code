    public void obtainJSON(Object stateInfo)
    {    
        Dispatcher.BeginInvoke(() => { 
            string url = "http://xxx.xxx.xxx" + stateInfo.ToString();
            var client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Decrypt);
            client.DownloadStringAsync(new Uri(url));
        });    
    }
