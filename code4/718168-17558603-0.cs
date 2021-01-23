    HttpClientHandler aHandler = new HttpClientHandler();
    IWebProxy proxy = new MyProxy(new Uri("http://xx.xx.xx.xxx:xxxx"));
    proxy.Credentials = new NetworkCredential("xxxx", "xxxx");
    aHandler.Proxy = proxy;
    HttpClient client = new HttpClient(aHandler);
