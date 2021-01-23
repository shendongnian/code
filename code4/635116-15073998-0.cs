    TValue value = this[key];
    var type = value.GetType();
    XmlSerializer valueSerializer = new XmlSerializer(type);
    writer.WriteStartElement("type");
    writer.WriteString(type.AssemblyQualifiedName); 
    //you can use FullName if you don't need to address external libraries
    writer.WriteEndElement();
    writer.WriteStartElement("content");
    valueSerializer.Serialize(writer, value);
    writer.WriteEndElement();
