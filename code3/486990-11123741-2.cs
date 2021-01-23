    using System.Net;
    ...
    public string GetHostName(string ipAddress)
    {
        try
        {
            IPHostEntry entry = Dns.GetHostEntry(ipAddress);
            if (entry != null)
            {
               return entry.HostName;
            }
        }
        catch (SocketException ex)
        {
           //unknown host or
           //not every IP has a name
           //log exception (manage it)
        }
        
        return null;
    }
