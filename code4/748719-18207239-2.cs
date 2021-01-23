    using System;
    using System.Xml;
    class Program
    {
        static void Main(string[] args)
        {
            // create the XML documents
            XmlDocument
                doc1 = new XmlDocument(),
                doc2 = new XmlDocument(),
                doc3 = new XmlDocument();
            // load the initial XMl into doc1
            doc1.Load("input.xml");
            // create the structure of doc2 and doc3
            doc2.AppendChild(doc2.ImportNode(doc1.FirstChild, false));
            doc3.AppendChild(doc3.ImportNode(doc1.FirstChild, false));
            doc2.AppendChild(doc2.ImportNode(doc1.DocumentElement, false));
            doc3.AppendChild(doc3.ImportNode(doc1.DocumentElement, false));
            // select the nodeImage
            var nodeImage = doc1.SelectSingleNode("//nodeImage");
            if (nodeImage != null)
            {
                // append to doc3
                var node3 = nodeImage.ParentNode.NextSibling;
                var n3 = doc3.ImportNode(node3, true);
                doc3.DocumentElement.AppendChild(n3);
                // append to doc2
                var n2 = doc2.ImportNode(nodeImage.ParentNode, true);
                n2.RemoveChild(n2.SelectSingleNode("//nodeImage").PreviousSibling);
                doc2.DocumentElement.AppendChild(n2);
                // remove from doc1
                nodeImage.ParentNode.ParentNode
                    .RemoveChild(nodeImage.ParentNode.NextSibling);
                nodeImage.ParentNode
                    .RemoveChild(nodeImage);
            }
            Console.WriteLine(doc1.InnerXml);
            Console.WriteLine(doc2.InnerXml);
            Console.WriteLine(doc3.InnerXml);
        }
    }
