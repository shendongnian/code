    XmlDocument document = new XmlDocument();
    document.Load("...");
    foreach (XmlNode node in document.SelectNodes("//CategoryList"))
    {
        var cat = node.InnerText;
    }
    foreach (XmlNode node in document.SelectNodes("//ContactEmail"))
    {
        var email = node.InnerText;
    }
