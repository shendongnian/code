        private static string swap(string xml)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xDoc.NameTable);
            namespaceManager.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");  
            var node1 = xDoc.SelectSingleNode(@"//child[@xml:id=""1""]",namespaceManager);
            var node2 = xDoc.SelectSingleNode(@"//child[@xml:id=""2""]",namespaceManager);
            var temp = node1.InnerXml;
            node1.InnerXml = node2.InnerXml;
            node2.InnerXml = temp;
            return xDoc.OuterXml;
        }
