    public void ReplaceXMLAttributeValueByIndex(string fullFilePath, string nodeName, int index, string valueToAdd)
        {
            FileInfo fileInfo = new FileInfo(fullFilePath);
            fileInfo.IsReadOnly = false;
            fileInfo.Refresh();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fullFilePath);
            try
            {
                XmlNode node = xmldoc.SelectSingleNode(nodeName);
                node.Attributes[index].Value = valueToAdd;
            }
            catch (Exception ex) 
            {
                //add code to see the error
            }
            xmldoc.Save(fullFilePath);
        }
