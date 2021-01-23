    // Create request
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/");
    // Apply settings (including proxy)
    request.Proxy = new WebProxy("{proxy address and port}");
    request.KeepAlive = false;
    request.Timeout = 100000;
    request.ReadWriteTimeout = 1000000;
    request.ProtocolVersion = HttpVersion.Version10;
    // Get response
    try
    {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        string html = reader.ReadToEnd();
    }
    catch (WebException)
    {
        // Handle web exceptions
    }
    catch (Exception)
    {
        // Handle other exceptions
    }
    // Process result
    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    htmlDoc.LoadHtml(html);
