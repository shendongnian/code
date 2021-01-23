    using System.Xml;
    ...
    XmlDocument doc = new XmlDocument();
    doc.Load("filename.xml"); //or doc.LoadXml(xmlString);
    XmlNodeList objects = doc.GetElementsByTagName("object"); //get list of objects from XML
    List<object> myObjects = new List<object> { new object()}; //replace this with your List<object>
    for (int i = 0; i < myObjects.Count; i++)
    {
        foreach (XmlNode o in objects)
        {
            if (o.Attributes["id"].Value == myObjects[i].id.ToString())
            {
                myObjects[i].Value1 = o.ChildNodes[0].InnerText;
                myObjects[i].Value2 = o.ChildNodes[1].InnerText;
            }
        }
    }
