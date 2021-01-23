    public static void ParseXml(XmlDocument xmlFile) 
    {
      XmlNodeList nodes = xmlFile.SelectNodes("//Engagement"); 
      foreach (XmlNode node in nodes) 
      { 
        string id = node.Attributes["id"].InnerText;
        // Do whatever you need to with each ID here.
      } 
    }
