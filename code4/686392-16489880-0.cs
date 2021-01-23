    webClient = new WebClient();
    webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
    webClient.DownloadStringAsync(new Uri(uri));
    void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        //remove "<!DOCTYPE HTML>"
        PageString = e.Result.Replace("<!DOCTYPE HTML>","").Trim();        
    }
    webBrowser.NavigateToString(PageString);
