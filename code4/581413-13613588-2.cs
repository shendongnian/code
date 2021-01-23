    private void LoadSources(object uri)
    {
        WebClient client = new WebClient();
        client.DownloadStringAsync(new Uri(uri.ToString(), UriKind.Absolute));
    
        client.DownloadStringCompleted += (s, a) =>
        {
            lock (thisLock)
            {
                try
                {
                    if (a.Error == null && !a.Cancelled)
                    {
                        this.Text.Add(a.Result);
                    }
                }
                finally
                {
                    this.CountDown.Signal();
                } 
            }
        };
    }
