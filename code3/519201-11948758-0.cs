    private string GetPageSource(string url)
    {
        string htmlSource = string.Empty;
        try
        {
            System.Net.WebProxy myProxy = new System.Net.WebProxy("Proxy IP", 8080);
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Proxy = myProxy;
                client.Proxy.Credentials = new System.Net.NetworkCredential("username", "password");
                htmlSource = client.DownloadString(url);
            }
        }
        catch (WebException ex)
        {
            // log any exceptions
        }
        return htmlSource;
    }
