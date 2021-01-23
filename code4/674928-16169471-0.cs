    XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml);
        XmlNodeList xnList = xmlDocument.SelectNodes("/Segments/Segment[@ID='AAA']/Elements");
        foreach (XmlNode xn in xnList)
        {
            if (xn.HasChildNodes)
            {
                foreach (XmlNode childNode in xn.ChildNodes)
                {
                    string id = childNode.Attributes["ID"].Value;
                }
            }
        }
