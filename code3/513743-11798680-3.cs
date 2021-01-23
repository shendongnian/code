    PListWriter writer = new PListWriter(pathFichier, null);    
    writer.Formatting = Formatting.Indented;
    writer.WriteStartDocument();
    writer.WriteDocType();
    writer.WriteStartElement("plist");
    writer.WriteAttributeString("version", "1.0");
    writer.WriteFullEndElement(); // plist
    writer.Close();
