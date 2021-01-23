    string xml = "<your xml>";
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    foreach (XmlNode xmlLoc in doc.DocumentElement.SelectNodes("loc"))
    {
        foreach (XmlNode xmlServername in xmlLoc.SelectNodes("Servername"))
        {
            Debug.WriteLine(string.Format("Servername={0}", xmlServername.InnerText));
            // xmlServername.InnerText will be \instance1\server1, etc.
        }
    }
