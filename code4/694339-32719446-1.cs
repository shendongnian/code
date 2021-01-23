        XmlWriterSettings settings = new XmlWriterSettings();
        
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Replace;
        settings.NewLineOnAttributes = true;       
                    using (
                        XmlWriter xmlWriter =
                            XmlWriter.Create(
                                Application.StartupPath + @"\Output\products.xml", settings))
                    {
                       
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteRaw("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
                        xmlWriter.WriteStartElement("products");
                     
