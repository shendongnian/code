    private void button1_Click(object sender, RoutedEventArgs e)
    {
        string url = "Your URL...";
        var webClient = new System.Net.WebClient();
        webClient.DownloadStringCompleted += HttpsCompleted;
        webClient.DownloadStringAsync(new Uri(url));
    }
    private void HttpsCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            XDocument xdoc = XDocument.Parse(e.Result, LoadOptions.None);
        }
    }
