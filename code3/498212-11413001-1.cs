    using System.Net;
    public static bool CheckIPValid(string strIP)
    {
        IPAddress result = null;
        return
            !String.IsNullOrEmpty(strIP) &&
            IPAddress.TryParse(strIP, out result);
    }
