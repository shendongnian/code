            System.Xml.XmlDocument myXmlDocument = new System.Xml.XmlDocument();
            myXmlDocument.Load("../myPath/web.config");
            foreach (System.Xml.XmlNode node in myXmlDocument["configuration"]["connectionStrings"])
            {
                if (node.Name == "add")
                {
                    if (node.Attributes.GetNamedItem("name").Value == "SCI2ConnectionString")
                    {
                        node.Attributes.GetNamedItem("connectionString").Value = "my new value blabla";
                    }
                }
            }
