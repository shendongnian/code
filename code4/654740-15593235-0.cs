    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var xmlFile = XElement.Load(@"c:\file.xml"); // Use your file here
            var blockquote = xmlFile.XPathSelectElement("/");
            var doc = new XDocument();
            doc.Add(new XElement("root"));
            var processedNodes = ProcessNode(blockquote);
            foreach (var node in processedNodes)
            {
                doc.Root.Add(node);
            }
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            using (var sw = XmlWriter.Create(sb, settings))
            {
                doc.WriteTo(sw);
            }
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(sb);
        }
        private static IEnumerable<XNode> ProcessNode(XElement parent)
        {
            foreach (var node in parent.Nodes())
            {
                if (node is XText)
                {
                    yield return node;
                }
                else if (node is XElement)
                {
                    var container = (XElement)node;
                    var copy = new XElement(container.Name.LocalName);
                    var children = ProcessNode(container);
                    foreach (var child in children)
                    {
                        copy.Add(child);
                    }
                    yield return copy;
                }
            }
        }
    }
