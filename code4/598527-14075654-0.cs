        var myOriginalXml = @"<Root>
                                <Data>Nack</Data>
                                <Data>Nelly</Data>
                              </Root>";
        var doc = new XmlDocument();
        doc.LoadXml(myOriginalXml);
        var sw = new StringWriter();
        var tx = XmlWriter.Create(sw, 
                    new XmlWriterSettings { 
                                 OmitXmlDeclaration = false, 
                                 ConformanceLevel= ConformanceLevel.Document });
        doc.Save(tx);
        var xmlString = sw.ToString();
