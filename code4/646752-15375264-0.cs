    public void CurlPMID()
    {
        // 1. The variable 'client' loses scope when this function exits.
        //    You may want to consider making it a class variable, so it doesn't
        //    get disposed early.
        WebClient client = new WebClient();
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(HttpsCompleted);
        // 2. You are calling the synchronous version of the download function.
        //    The synchronous version does not call any completion handlers.
        //    When the synchronous call returns, the download has completed.
        // 3. You are calling the wrong function here.  Based on your completion handler, 
        //    you should be calling DownloadStringAsync(). If you want synchronous 
        //    behavior, call DownloadString() instead.
        client.DownloadData(this.pmid_url);
    }
