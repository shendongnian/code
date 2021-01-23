    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.ContentType] = "text/xml";
        string xml = "<foo>Bar</foo>";
        string result = client.UploadString("http://192.168.220.12:5000", xml);
    }
