    string getPageSource(string URL)
    {
        System.Net.WebClient webClient = new System.Net.WebClient();
        string strSource = webClient.DownloadString(URL);
        webClient.Dispose();
        return strSource;
    }
