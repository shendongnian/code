    public void Downloader()
    {
        using (WebClient wc = new WebClient())
        {
            wc.DownloadStringCompleted += (s, e) =>
            {
                string page = e.Result;
            };
            wc.DownloadStringAsync(new Uri("http://chatroll.com/rotternet"));
        }
    }
