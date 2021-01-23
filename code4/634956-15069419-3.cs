    static public Dictionary<string, string> getBoxValue(string username)
    {
         Dictionary<string, string> listofbox = new Dictionary<string, string>();
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(@"./" + username + ".xml");
        XmlNode root = xmldoc.DocumentElement;
        foreach (XmlNode box in root)
        {
     listofbox.Add(box.Attributes[0].Value.ToString(),box.Attributes[1].Value.ToString()); 
        }
    return listofbox;
    }
