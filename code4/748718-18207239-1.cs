    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument
                doc1 = new XmlDocument(),
                doc2 = new XmlDocument(),
                doc3 = new XmlDocument();
            doc1.Load("input.xml");
            doc2.AppendChild(doc2.ImportNode(doc1.FirstChild, false));
            doc3.AppendChild(doc3.ImportNode(doc1.FirstChild, false));
            doc2.AppendChild(doc2.ImportNode(doc1.DocumentElement, false));
            doc3.AppendChild(doc3.ImportNode(doc1.DocumentElement, false));
            var nodeImage = doc1.SelectSingleNode("//nodeImage");
            var node3 = nodeImage.ParentNode.NextSibling;
            var n3 = doc3.ImportNode(node3,true);
            doc3.DocumentElement.AppendChild(n3);
            var n2 = doc2.ImportNode(nodeImage.ParentNode, true);
            n2.RemoveChild(n2.SelectSingleNode("//nodeImage").PreviousSibling);
            doc2.DocumentElement.AppendChild(n2);
            nodeImage.ParentNode.ParentNode.RemoveChild(nodeImage.ParentNode.NextSibling);
            nodeImage.ParentNode.RemoveChild(nodeImage);
            System.Console.WriteLine(doc1.InnerXml);
            System.Console.WriteLine(doc2.InnerXml);
            System.Console.WriteLine(doc3.InnerXml);
        }
    }
