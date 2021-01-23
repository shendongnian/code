    public void WriteXml(System.Xml.XmlWriter writer)
    {
        writer.WriteStartElement("Target");
        writer.WriteString(Name);
        writer.WriteEndElement(); 
    }
