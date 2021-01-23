    HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
    HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
    string xml = string.Empty;
    using (GZipStream gzip = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
    using (StreamReader sr = new StreamReader(gzip))
    {
      xml = sr.ReadToEnd();
    }
    
    XmlDocument xmlDoc = new XmlDocument();
    //xml = xml.Replace((char)(0x1F), ' ');
    xmlDoc.LoadXml(xml);
