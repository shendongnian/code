    public void CurlPMID()
    {
        WebClient client = new WebClient();
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(HttpsCompleted);
        client.DownloadStringAsync(this.pmid_url);
    }
