    using (XmlWriter writer = XmlWriter.Create(MapPath(xmlFilePath)))
    {
       writer.WriteStartDocument();
       writer.WriteStartElement("Tasks");
       writer.WriteStartElement("Task");
       writer.WriteAttributeString("Id", t.Id.ToString());
       writer.WriteAttributeString("NodeId", t.Node.Id.ToString());
      // The XmlNode needs to be inside here //
       writer.WriteRaw(the_node.OuterXml);
       writer.WriteEndElement();
       writer.WriteEndElement();
       writer.WriteEndDocument();
    }
