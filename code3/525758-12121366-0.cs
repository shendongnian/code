    string remoteUri = "http://whois.domaintools.com/94.100.179.159";
    HtmlDocument doc = new HtmlDocument();
    using (WebClient myWebClient = new WebClient())
    {
      myWebClient.Headers.Add(HttpRequestHeader.UserAgent, "some browser user agent");
      doc.Load(myWebClient.OpenRead(remoteUri));
    }
    doc.Save("file1.htm");
