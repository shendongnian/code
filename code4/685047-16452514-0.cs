    XmlDocument doc = new XmlDocument();
    doc.LoadXml(innerXml);
    XmlNodeList ErrorIdTags = doc.GetElementsByTagName("ErrorId");
    if(ErrorIdTags.Count <= 1)
    {
        // The tag could not be fond
    }
    else
    {
        // The tag could be found!
        string ErrorId = ErrorIdTags[0].InnerText;
    }
