    public class XMLFileManager
    {        
        public List<string> SplitXMLFile(string fileName, int startingLevel, int numEntriesPerFile)
        {
            List<string> resultingFilesList = new List<string>();
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(fileName, readerSettings);
            XmlWriter writer = null;
            int fileNum = 1;
            int entryNum = 0;
            bool writerIsOpen = false;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            Dictionary<int, XmlNodeItem> higherLevelNodes = new Dictionary<int, XmlNodeItem>();
            int hlnCount = 0;
            string fileIncrementedName = GetIncrementedFileName(fileName, fileNum);
            resultingFilesList.Add(fileIncrementedName);
            writer = XmlWriter.Create(fileIncrementedName, settings);
            writerIsOpen = true;
            writer.WriteStartDocument();
            int treeDepth = 0;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:                        
                        treeDepth++;
                        if (treeDepth == startingLevel)
                        {
                            entryNum++;
                            if (entryNum == 1)
                            {                                
                                if (fileNum > 1)
                                {
                                    fileIncrementedName = GetIncrementedFileName(fileName, fileNum);
                                    resultingFilesList.Add(fileIncrementedName);
                                    writer = XmlWriter.Create(fileIncrementedName, settings);
                                    writerIsOpen = true;
                                    writer.WriteStartDocument();
                                    for (int d = 1; d <= higherLevelNodes.Count; d++)
                                    {
                                        XmlNodeItem xni = higherLevelNodes[d];
                                        switch (xni.XmlNodeType)
                                        {
                                            case XmlNodeType.Element:
                                                writer.WriteStartElement(xni.NodeValue);
                                                break;
                                            case XmlNodeType.Text:
                                                writer.WriteString(xni.NodeValue);
                                                break;
                                            case XmlNodeType.CDATA:
                                                writer.WriteCData(xni.NodeValue);
                                                break;
                                            case XmlNodeType.Comment:
                                                writer.WriteComment(xni.NodeValue);
                                                break;
                                            case XmlNodeType.EndElement:
                                                writer.WriteEndElement();
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        if (writerIsOpen)
                        {
                            writer.WriteStartElement(reader.Name);
                        }
                        if (treeDepth < startingLevel)
                        {
                            hlnCount++;
                            XmlNodeItem xni = new XmlNodeItem();
                            xni.XmlNodeType = XmlNodeType.Element;
                            xni.NodeValue = reader.Name;
                            higherLevelNodes.Add(hlnCount, xni);
                        }
                        break;
                    case XmlNodeType.Text:
                        if (writerIsOpen)
                        {
                            writer.WriteString(reader.Value);
                        }
                        if (treeDepth < startingLevel)
                        {
                            hlnCount++;
                            XmlNodeItem xni = new XmlNodeItem();
                            xni.XmlNodeType = XmlNodeType.Text;
                            xni.NodeValue = reader.Value;
                            higherLevelNodes.Add(hlnCount, xni);
                        }
                        break;
                    case XmlNodeType.CDATA:
                        if (writerIsOpen)
                        {
                            writer.WriteCData(reader.Value);
                        }
                        if (treeDepth < startingLevel)
                        {
                            hlnCount++;
                            XmlNodeItem xni = new XmlNodeItem();
                            xni.XmlNodeType = XmlNodeType.CDATA;
                            xni.NodeValue = reader.Value;
                            higherLevelNodes.Add(hlnCount, xni);
                        }
                        break;
                    case XmlNodeType.Comment:
                        if (writerIsOpen)
                        {
                            writer.WriteComment(reader.Value);
                        }
                        if (treeDepth < startingLevel)
                        {
                            hlnCount++;
                            XmlNodeItem xni = new XmlNodeItem();
                            xni.XmlNodeType = XmlNodeType.Comment;
                            xni.NodeValue = reader.Value;
                            higherLevelNodes.Add(hlnCount, xni);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (entryNum == numEntriesPerFile && treeDepth == startingLevel || treeDepth==1)
                        {
                            if (writerIsOpen)
                            {
                                fileNum++;
                                writer.WriteEndDocument();
                                writer.Close();
                                writerIsOpen = false;
                                entryNum = 0;
                            }                            
                        }
                        else
                        {
                            if (writerIsOpen)
                            {
                                writer.WriteEndElement();
                            }
                            if (treeDepth < startingLevel)
                            {
                                hlnCount++;
                                XmlNodeItem xni = new XmlNodeItem();
                                xni.XmlNodeType = XmlNodeType.EndElement;
                                xni.NodeValue = string.Empty;
                                higherLevelNodes.Add(hlnCount, xni);
                            }
                        }
                        treeDepth--;
                        break;
                }
            }
            return resultingFilesList;
        }
        private string GetIncrementedFileName(string fileName, int fileNum)
        {
            return fileName.Replace(".xml", "") + "_" + fileNum + "_" + ".xml";
        }
    }
