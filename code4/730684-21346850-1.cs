    static void Main(string[] args)
    {
        IPAddress localhost = IPAddress.Parse("127.0.0.1");
        IPEndPoint src_http = new IPEndPoint(localhost, 9091);
        IPEndPoint des_tor = new IPEndPoint(localhost, 9050);
        HttpOverSocksProxy proxy = new HttpOverSocksProxy(src_http, des_tor, ProxyTypes.Socks5);
        proxy.Start();
        WebClientExt client = new WebClientExt();
        client.Proxy = new WebProxy(src_http.ToString(), false);
        string res = client.DownloadString("http://en.wikipedia.org/wiki/HTTP_compression");
        Console.WriteLine(res);
        Console.WriteLine("Done");
        Console.ReadKey();
    }
