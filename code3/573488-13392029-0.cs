        static void Main(string[] args)
        {
            XmlDocument myXmlDoc = new XmlDocument();
            myXmlDoc.LoadXml("<MyTag>Inner Text</MyTag>");
            XmlNodeReader nodeReader = new XmlNodeReader(myXmlDoc);
            while (nodeReader.Read())
            {
                Console.WriteLine(
                    "Node Type : {0}, Node Name: {1}, Node Value {2}", 
                    nodeReader.NodeType, 
                    nodeReader.Name, 
                    nodeReader.Value);
            }
        }
