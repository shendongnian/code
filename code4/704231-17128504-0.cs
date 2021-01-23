    WebProxy proxy = (WebProxy) WebRequest.DefaultWebProxy;
    if (proxy.Address.AbsoluteUri != string.Empty)
    {
        Console.WriteLine("Proxy URL: " + proxy.Address.AbsoluteUri);
        client.Proxy = proxy;
    }
