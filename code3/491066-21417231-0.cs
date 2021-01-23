    try
    {
        var netCred = new NetworkCredential { UserName = "ununun", Password = @"pwpwpw", Domain = @"domain" };
        var webProxy = new WebProxy { Credentials = netCred };
        var webClient = new WebClient { Proxy = webProxy };
        webClient.DownloadFile(url, saveFileName);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception:\n{0}\n{1}", ex.Message, ex.StackTrace);
        return;
    }
