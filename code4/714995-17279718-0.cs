            public static void RemoveDuplicates(string filePath)
        {
            XmlDocument reader = new XmlDocument();
            reader.Load(filePath);
            
            bool foundApplicable = false;
            ArrayList removeNodes = new ArrayList();
            foreach(XmlNode node in reader.GetElementsByTagName("transaction"))
            {
                if (node.FirstChild != null && node.FirstChild.Attributes["type"].Value == "SetActiveLocale")
                {
                    if (node.SelectSingleNode("action/inputparams/param") != null && node.SelectSingleNode("action/inputparams/param").InnerText == "en")
                    {
                        if (foundApplicable)
                        {
                            // I have to use a list because foreach breaks if I remove a node while the loop is working
                            removeNodes.Add(node);
                        }
                        else
                            foundApplicable = true;
                    }
                }
            }
            foreach (XmlNode node in removeNodes)
            {
                node.ParentNode.RemoveChild(node);
            }
            reader.Save(filePath);
        }
