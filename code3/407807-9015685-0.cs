    class MyClient : WebClient
    {
        public bool HeadOnly { get; set; }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest req = base.GetWebRequest(address);
            if (HeadOnly && req.Method == "GET")
            {
                req.Method = "HEAD";
            }
            return req;
        }
    }
    private bool headOnly;
    public bool HeadOnly {
        get {return headOnly;}
        set {headOnly = value;}
    }
    using(var client = new MyClient()) {
        client.HeadOnly = true;
        // fine, no content downloaded
        string s1 = client.DownloadString("http://google.com");
        // throws 404
        string s2 = client.DownloadString("http://google.com/silly");
    }
