                XmlNodeList itemNodes = xmlDoc1.GetElementsByTagName("item");
                if (itemNodes.Count > 0)
                {
                   foreach (XmlNode node in itemNodes)
                   {
                     ids3list.Add(node.Attributes["href"].Value);
                   }
                }
