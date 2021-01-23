            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("filename.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("//FeaturedProduct"))
            {
                XmlElement newElement = xDoc.CreateElement("newElementName");
                XmlAttribute newAttribute = xDoc.CreateAttribute("AttributeName");
                newAttribute.Value = "attributeValue";
                newElement.Attributes.Append(newAttribute);
                xNode.AppendChild(newElement);
            }
