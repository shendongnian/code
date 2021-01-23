        static void SplitXMLDocument() 
        {
            string strFileName;
            string strSeq;
            XmlDocument doc = new XmlDocument();             // The input file
            doc.Load("D:\\Rick\\Computer\\XML\\AnimalBatch.xml");
            XmlNodeList nl = doc.DocumentElement.SelectNodes("//Animals/Animal");
            foreach (XmlNode n in nl)
            {
                strSeq = n.Attributes["id"].Value;           // Animal nodes have an id attribute
                XmlDocument outdoc = new XmlDocument();      // Create the outdoc xml document
                XmlNode targetNode = outdoc.CreateElement("Animal"); // Create a separate node to hold the Animal element
                targetNode = outdoc.ImportNode(n, true);     // Bring over that Animal
                targetNode.Attributes.RemoveAll();           // Remove the id attribute in <Animal id="1001">
                
                outdoc.ImportNode(targetNode, true);         // place the node n into outdoc
                outdoc.AppendChild(targetNode);              // AppendChild to make it stick
                
                strFileName = "Animal_" + strSeq + ".xml";                
                outdoc.Save(Console.Out); Console.WriteLine();
                outdoc.Save("D:\\Rick\\Computer\\XML\\" + strFileName);
                Console.WriteLine();
            }
        }
