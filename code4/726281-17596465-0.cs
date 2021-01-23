            string xmlText = File.ReadAllText("C:\\Users\\virens\\Desktop\\Testxml.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
            XmlNodeList parentNode = doc.GetElementsByTagName("DOCUMENT");
            IEnumerator testnodes = parentNode[0].ChildNodes.GetEnumerator();
            List<string> p = new List<string>();
            string classe = "";
            while (testnodes.MoveNext())
            {
                XmlNode node = (XmlNode)testnodes.Current;
                if (node.Name == "TIF_FILENAME")
                {
                    Console.WriteLine("Yai I got it");
                    Console.WriteLine(node.InnerText);
                }
            } 
