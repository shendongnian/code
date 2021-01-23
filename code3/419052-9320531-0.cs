    public static void SetProxy(string proxyAddress, string userName, string password, string exceptions)
    {
        var credential = new NetworkCredential(userName, password);
        string[] bypassList = null;
        if (!string.IsNullOrEmpty(exceptions))
        {
            bypassList = exceptions.Split(';');
        }
        WebRequest.DefaultWebProxy = new WebProxy(proxyAddress, true, bypassList, credential);
    }
