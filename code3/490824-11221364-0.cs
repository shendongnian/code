    writer.WriteStartDocument();
    writer.WriteStartElement("Book");
    writer.WriteStartElement("Title");
    writer.WriteString("Title");
    writer.WriteEndElement();
    writer.WriteStartElement("Content");
    writer.WriteString("Content");
    writer.WriteEndElement();
    // insert your new data here
    writer.WriteEndElement();
    writer.WriteEndDocument();
