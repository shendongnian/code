    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
    
    IWebProxy proxy = request.Proxy;                    
    if (proxy != null)
    {
        Console.WriteLine("Proxy: {0}", proxy.GetProxy(request.RequestUri));
    }
    else
    {
        Console.WriteLine("Proxy is null; no proxy will be used");
    }
    
    WebProxy myProxy = new WebProxy();
    Uri newUri = new Uri("http://20.154.23.100:8888");
    // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
    myProxy.Address = newUri;
    // Create a NetworkCredential object and associate it with the 
    // Proxy property of request object.
    myProxy.Credentials = new NetworkCredential("userName", "password");
    request.Proxy = myProxy;
