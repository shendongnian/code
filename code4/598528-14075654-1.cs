        var myOriginalXml = @"<Root>
                                <Data>Nack</Data>
                                <Data>Nelly</Data>
                              </Root>";
        var doc = new XmlDocument();
        doc.LoadXml(myOriginalXml);
        var ms = new MemoryStream();
        var tx = XmlWriter.Create(ms, 
                    new XmlWriterSettings { 
                                 OmitXmlDeclaration = false, 
                                 ConformanceLevel= ConformanceLevel.Document,
                                 Encoding = UTF8Encoding.UTF8 });
        doc.Save(tx);
        var xmlString = UTF8Encoding.UTF8.GetString(ms.ToArray());
