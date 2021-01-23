    WebClient myWebClient = new WebClient();
    myWebClient.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); // If you need to simulate a specific browser
    byte[] myDataBuffer = myWebClient.DownloadData (remoteUri);
    string download = Encoding.ASCII.GetString(myDataBuffer);
    // This is verbatim from MSDN... unfortunately their example does not dispose
    // of myWebClient (it implements IDisposable).  You should wrap use of a WebClient
    // in a using statement.
