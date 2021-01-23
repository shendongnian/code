            XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
            xmlDoc.Load("tsco.xml"); //* load the XML document from the specified file.
            richComResults.Text = string.Empty;
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("item"); // You can also use XPath here
            StringBuilder sb = new StringBuilder();
            foreach (XmlNode node in nodes)
            {                
                foreach (XmlNode child in node.ChildNodes)
                    sb.AppendLine(string.Format("{0}:\t{1}", child.Name,  child.FirstChild == null ? string.Empty : child.FirstChild.Value));                
            }
            richComResults.Text = sb.ToString();            
