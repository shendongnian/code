    public bool UrlIsValid(string url) {
       return UrlIsValid(new Uri(url));
    }
    
    
    public bool UrlIsValid(Uri url)
    {
        bool br = false;
        try
        {
             IPHostEntry ipHost =  Dns.GetHostEntry(url.DnsSafeHost);
             br = true;
        }
        catch (SocketException)
        {
            br = false;
        }
        return br;
    }
