    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument
                doc1 = new XmlDocument(),
                doc2 = new XmlDocument(),
                doc3 = new XmlDocument();
            doc1.Load("input.xml");
            doc2.AppendChild(doc2.ImportNode(doc1.DocumentElement, false));
            doc3.AppendChild(doc3.ImportNode(doc1.DocumentElement, false));
            var nodeImage = doc1.SelectSingleNode("//nodeImage");
            var node3 = nodeImage.ParentNode.NextSibling;
            var n3 = doc3.ImportNode(node3,true);
            doc3.DocumentElement.AppendChild(n3);
            var n2 = doc2.ImportNode(nodeImage, true);
            doc2.DocumentElement.AppendChild(n2);
            nodeImage.ParentNode.NextSibling.RemoveAll();
            nodeImage.RemoveAll();
        }
    }
