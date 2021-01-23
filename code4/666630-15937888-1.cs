    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    XmlWriter writer = XmlWriter.Create("C:\\Users\\fthompson11\\WebFile.xml",
      settings);
    writer.WriteStartDocument();
    writer.WriteComment("This is to write the connection strings, text file location, and report destination.");
    // the AdminPaths
    writer.WriteStartElement("AdminPaths");
    writer.WriteStartElement("AdminPath");
    writer.WriteAttributeString("Name", "sqlConnection1");
    writer.WriteAttributeString("connectionString", "asdf");
    writer.WriteEndElement();
            
    // the TextPath's
    writer.WriteStartElement("TextPath");
    writer.WriteStartElement("Text");
    writer.WriteAttributeString("Key", "Path");
    writer.WriteAttributeString("Value", "Test3");
    writer.WriteEndElement();
    writer.WriteStartElement("Text");
    writer.WriteAttributeString("Key", "Report");
    writer.WriteAttributeString("Value", "Test2");
    writer.WriteEndElement();
            
    writer.WriteEndElement(); // </AdminPaths>
    writer.WriteEndDocument();
    writer.Flush();
    writer.Close();
