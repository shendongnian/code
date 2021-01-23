    HashSet<String> allowedDomains = new HashSet<String>()
                                     {
                                             "domain1.com",
                                             "domain2.com"
                                     };
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("url");
    using (WebResponse response = request.GetResponse())
    {
        if (!allowedDomains.Contains(response.ResponseUri.Host))
        {
            throw new IllegalDomainException();
        }
        using (Stream stream = response.GetResponseStream())
        {
            if (stream == null)
            {
                return null;
            }
            return stream;
        }
    }
