     int port = 1048; //<--- This is your value
     bool isAvailable = true;
    
     IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
     TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
    
     foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
     {
       if (tcpi.LocalEndPoint.Port==port)
       {
         isAvailable = false;
         break;
       }
     }
    
    if(isAvailable == true)
    {
    // connect.
    }
