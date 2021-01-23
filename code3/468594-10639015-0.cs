    XmlTextWriter writer = new XmlTextWriter(...);
    
    writer.StartDocument();
 
    writer.WriteStartElement("property");
    writer.WriteAttributeString("name", "project.name");
    writer.WriteAttributeString("value", projectName);
    writer.WriteEndElement();
    writer.EndDocument();
    writer.Close();
