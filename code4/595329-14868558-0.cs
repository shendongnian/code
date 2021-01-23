    System.Net.ServicePointManager.DefaultConnectionLimit = 100; // Just selected a random number for testing greater than 2
    System.Net.ServicePointManager.SetTcpKeepAlive(true, 30, 30); // 30 is based on my server i'm hitting
    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
    
    request.KeepAlive = true;
 
