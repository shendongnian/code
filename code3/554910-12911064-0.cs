    public XmlElement SearchXML(string name)
    {
        XmlDocument xDoc = new XmlDocument();
        string filePath = ConfigurationManager.AppSettings["path"];
        xDoc.Load(filePath);
        string xQryStr = "//NewPatient[Name='" + name + "']";
  
        XmlNodeList listOfNodes = xDoc.SelectNodes(xQryStr);
        foreach(XmlNode node in listOfNodes
        {
           // do something with that list of XML nodes you've selected....
           // XmlElement xmlEle = node;
           // return xmlEle;
        }
    }
