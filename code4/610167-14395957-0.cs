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
        myWebRequest.Proxy=proxy;
    }
    HttpWebResponse myWebResponse=(HttpWebResponse)myWebRequest.GetResponse();
