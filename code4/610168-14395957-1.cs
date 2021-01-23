    // Create a new request to the mentioned URL.				
    HttpWebRequest myWebRequest= (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
    // Obtain the 'Proxy' of the  Default browser.  
    IWebProxy proxy = myWebRequest.Proxy;
    if (proxy != null)
    {
        // Create a NetworkCredential object and associate it with the  
        // Proxy property of request object.
        proxy.Credentials=new NetworkCredential(username,password);
        // or 
        proxy.UseDefaultCredentials = true; 
        // try forcing the proxy to use http (just to the proxy not from proxy to server)
        Uri proxyAddress = proxy.Address;
        proxyAddress.Scheme = "http";
        myWebRequest.Proxy=proxy;
    }
    HttpWebResponse myWebResponse=(HttpWebResponse)myWebRequest.GetResponse();
