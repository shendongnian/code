            XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
            xmlDoc.Load("tsco.xml"); //* load the XML document from the specified file.
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("item"); // You can also use XPath here
            foreach (XmlNode node in nodes)
            {
                StringBuilder sb = new StringBuilder();
                foreach (XmlNode child in node.ChildNodes)
                    sb.AppendLine(string.Format("{0}:\t{1}", child.Name, child.FirstChild.Value));
                richComResults.Text = sb.ToString();
            }
            Console.ReadLine();
