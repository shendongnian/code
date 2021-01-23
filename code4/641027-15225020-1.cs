            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\test.xml");
            List<string> attributes = new List<string>();
            List<XmlNode> nodes = new List<XmlNode>();
            XmlNode node = xml.FirstChild;
            foreach (XmlElement n in node.ChildNodes)
            {
                XmlAttributeCollection atributos = n.Attributes;
                foreach (XmlAttribute at in atributos)
                {
                    if(at.LocalName.Contains("attribute"))
                    {
                        attributes.Add(at.Value);
                    }
                }
            }
