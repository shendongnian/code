    WebProxy proxy = new WebProxy(proxyAddress);
    proxy.Credentials = new NetworkCredential("username", "password", "domain");
    proxy.UseDefaultCredentials = true;
    WebRequest.DefaultWebProxy = proxy;
    HttpWebRequest request = new HttpWebRequest();
    request.Proxy = proxy;
