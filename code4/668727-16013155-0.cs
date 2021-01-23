    LocalResource localResource = RoleEnvironment.GetLocalResource("myLocalStorage");
    string PathToFile = Path.Combine(localResource.RootPath, "mycode.exe");
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
    WebClient webclient = new WebClient();
    webclient.DownloadFile(codeUri, PathToFile);
    
    Process p = new Process(); //...
