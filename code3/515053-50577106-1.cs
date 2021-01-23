    public static bool PortInUse(int  port)
    {
        bool inUse = false;
    
        IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        IPEndPoint [] ipEndPoints = ipProperties.GetActiveTcpListeners();
    
     
        foreach(IPEndPoint endPoint in ipEndPoints)
        {
            if(endPoint.Port == port)
            {
                inUse = true;
                break;
            }
        }
     
    
        return  inUse;
    }
