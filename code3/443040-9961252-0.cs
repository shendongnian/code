    WebClient wc = new WebClient();
    string pageContent;
    try {
        pageContent = wc.DownloadString("http://example.com/page");
    }
    catch (WebException ex)
    {
        Stream receiveStream = ex.Response.GetResponseStream();
        Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        StreamReader readStream = new StreamReader( receiveStream, encode );
        pageContent=readStream.ReadToEnd();
    }
