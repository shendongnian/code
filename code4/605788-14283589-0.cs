    XmlDocument xDoc = new XmlDocument();
    xDoc.Load("filename.xml");
    string val = xDoc.SelectSingleNode("//ElementName").Attributes["attributeName"].Value;
    XmlDocument xDoc2 = new XmlDocument();
    XmlElement ele = xDoc2.CreateElement("ElementName2");
    XmlAttribute att = xDoc2.CreateAttribute("attributeName2");
    att.Value = val;
    ele.Attributes.Append(att);
    xDoc2.AppendChild(ele);
