    System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
    //...
    using (var client = new SrvClient())
    {
    	client.ClientCredentials.UserName.UserName = "usr";
    	client.ClientCredentials.UserName.Password = "psw";
        //...
    }
