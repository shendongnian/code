    private bool IsInternetAvailable()
    {
        try
        {
            Dns.GetHostEntry("www.google.com"); //using System.Net;
            return true;
        } catch (SocketException ex) {
            return false;
        }
    }
