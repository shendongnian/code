    public static string getDNSName(string myIP)
    {
     System.Net.IPHostEntry ip = System.Net.Dns.GetHostByAddress(myIP);
     return ip.HostName;
    }
