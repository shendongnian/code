    Uri uri = new Uri("http://whatever.com");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
    
    NetworkCredential networkCredentials = new NetworkCredential();
    networkCredentials.Domain = "Domain";
    networkCredentials.UserName = "User";
    networkCredentials.Password = "Pass";
    
    CredentialCache cc = new CredentialCache();
    cc.Add(uri, "Basic", networkCredentials); //NTLM can be used here, but Basic usually works.
    
    request.Credentials = cc;
    request.Method = WebRequestMethods.Http.Get;
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
    	...
    }
