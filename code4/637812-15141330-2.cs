     public List<string> LoadAllNodes(string siteMapFileName)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(siteMapFileName);
            var urls = new List<string>();
            AddNodes(doc.DocumentElement.ChildNodes, urls);
            return urls;
        }
        private void AddNodes(XmlNodeList nodes, List<string> urls)
        {            
            foreach (XmlNode child in nodes.OfType<XmlElement>())
            {
                urls.Add(child.Attributes["url"].Value);
                AddNodes(child.ChildNodes, urls);
            }
        }
