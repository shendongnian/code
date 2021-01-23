    WebRequest request = WebRequest.Create(url);
    request.Credentials = new NetworkCredential("usernamne", "password");
    using (WebResponse response = request.GetResponse()) 
    {
        using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
        {
            // Blah blah...
        }
    }
