        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        
        ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
    
     WebClient webclient = new WebClient();
    webclient.DownloadFile(new Uri(URIPath), LocalPath);
