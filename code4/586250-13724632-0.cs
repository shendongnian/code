    CreateTag("//NODE1/NODE2", "TAG_NAME", tagContent);
        private void CreateTag(string xPath, string tag, string tagContent)
        {
            XmlNode node = _xml.SelectSingleNode(xPath);
            XmlElement element = _xml.CreateElement(tag);
            element.InnerText = tagContent;
            node.AppendChild(element);
        }
