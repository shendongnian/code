    WebProxy p = new WebProxy("localproxyIP:8080", true);
    p.Credentials = new NetworkCredential("domain\\user", "password");
    WebRequest.DefaultWebProxy = p;
    WebClient client = new WebClient();
    **client.Proxy = p;**
    string downloadString = client.DownloadString("http://www.google.com");
