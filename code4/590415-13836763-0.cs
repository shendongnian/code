    public static Stream GetResponseStream() 
    {
        var uri = new Uri(url, true);
        WebRequest request = WebRequest.Create(uri);
        request.Method = WebRequestMethods.Http.Get;
        WebResponse response = request.GetResponse();
        return response.GetResponseStream();
    }
    public static XDocument GetXDocument()
    {
        using(Stream stream = GetResponseStream())
        {
            XmlReader xmlReader = XmlReader.Create(stream);
            return XDocument.Load(xmlReader);
        }
    }
