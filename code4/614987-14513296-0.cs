    XDocument doc = XDocument.Parse(XmlResponse)
    XElement firstElement = doc.Elements().First();
    if(firstElement.Name.LocalName == "ERROR")
    {
        string errorType = firstElement.Attribute("type").Value;
        string message = firstElement.Value;
        // Process error
    }
    else
    {
        // It is an info
    }
