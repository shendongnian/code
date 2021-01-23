        static void SplitXMLReaderSubTree()
        {
            string strFileName;
            string strSeq = "";
            XmlReader doc = XmlReader.Create("C:\\AnimalBatch.xml");
            while (!doc.EOF)
            {
                if ( doc.Name == "Animal"  && doc.NodeType == XmlNodeType.Element )
                {
                    strSeq = doc.GetAttribute("id");
                    XmlReader inner = doc.ReadSubtree();
                    inner.Read();
                    XmlDocument outdoc = new XmlDocument();
                    XmlDeclaration xmlDeclaration = outdoc.CreateXmlDeclaration("1.0", "utf-8", null);
                    XmlElement myElement;
                    myElement = outdoc.CreateElement(doc.Name);
                    myElement.InnerXml = inner.ReadInnerXml();
                    inner.Close();
                    myElement.Attributes.RemoveAll();
                    outdoc.InsertBefore(xmlDeclaration, outdoc.DocumentElement);
                    outdoc.ImportNode(myElement, true);
                    outdoc.AppendChild(myElement);
                    strFileName = "Animal_" + strSeq + ".xml";
                    outdoc.Save("C:\\" + strFileName);                    
                }
                else
                {
                    doc.Read();
                }
            }
