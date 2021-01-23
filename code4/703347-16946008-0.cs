    XmlDocument x = new XmlDocument();
    
    x.LoadXml("<xml goes here/>");
    
    string offername = x.GetElementsByTagName("offerName")[0].InnerText;
    string offervalue = x.GetElementsByTagName("value")[0].InnerText;
    
    string linkUrl = x.GetElementsByTagName("link")[0].Attributes["url"].Value;
    string thumb = x.GetElementsByTagName("thumbnail")[0].Attributes["url"].Value;
