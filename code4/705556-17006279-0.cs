            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://s3.amazonaws.com/themall/");
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("ns", "http://s3.amazonaws.com/doc/2006-03-01/");
            XmlNode titleNode = xmlDoc.SelectSingleNode("//ns:Name", namespaceManager);
            if (titleNode != null)
                Console.WriteLine(titleNode.InnerText);
            Console.ReadKey();
