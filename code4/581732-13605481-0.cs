       string str ="";
       using (var reader = new StreamReader(BackupManager.xml))
                {
                    var all = reader.ReadToEnd();
                    StringReader stringReader = new StringReader(all);
                    XmlReader xmlReader = XmlTextReader.Create(stringReader,new System.Xml.XmlReaderSettings() { IgnoreWhitespace = true, IgnoreComments = true });
                    while (xmlReader.Read())
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "directory")
                             str = xmlReader["value"];
                }
