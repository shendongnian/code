            using System.Xml;
            using.System.Xml.Linq;
            XmlReader reader = XmlReader.Create("http://www.studiovincent.net/list.xml");
            XElement el = XElement.Load(reader);
            reader.Close();
    
            var items = el.Elements("resources").Elements("resource").Descendants().DescendantNodes();
    
            foreach (XNode node in items)
            {
                Console.WriteLine(node.ToString());
            }
