    using (var client = new WebClient())
    {
        string strXml = client.DownloadString(new Uri(url));
        xmlDoc.LoadXml(strXml);
    }
