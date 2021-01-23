    WebClient web = new WebClient();
    web.Headers["Accept-Encoding"] = "gzip,deflate,sdch";
    var zip = new System.IO.Compression.GZipStream(
        web.OpenRead("http://www.whiskymag.fr/feed/?post_type=sortir"), 
        System.IO.Compression.CompressionMode.Decompress);
    string rss = new StreamReader(zip, Encoding.UTF8).ReadToEnd();
