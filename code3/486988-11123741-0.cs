    using System.Net;
    ...
    public string GetHostName(string ipAddress)
    {
        try
        {
            IPHostEntry entry = Dns.GetHostEntry(ipAddress);
            if (hostEntry != null)
            {
               return entry.HostName;
            }
        }
        catch (Exception ex)
        {
           //not every IP has a name
           //log exception (manage it)
        }
        
        return null;
    }
