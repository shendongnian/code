    MemoryStream memoryStream = new MemoryStream();
    XmlSerializer xs = new XmlSerializer(typeof(TypeOfObjectToBeConverted));
    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
    xs.Serialize(xmlTextWriter, objectToBeConverted);
    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
    memoryStream.Position = 0;
    System.Data.SqlTypes.SqlXml obj = new System.Data.SqlTypes.SqlXml(memoryStream);
