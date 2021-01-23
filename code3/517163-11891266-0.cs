    public async void Downloader()
    {
        using (WebClient wc = new WebClient())
        {
            string page = await wc.DownloadStringTaskAsync("http://chatroll.com/rotternet");
        }
    }
