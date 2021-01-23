    public void WriteXml(XmlWriter writer)
    {
      //First example xml element
      writer.WriteStartElement("Item1");
      writer.WriteAttributeString("Name", Name);
      writer.WriteAttributeString("Price", Price);
      writer.WriteAttributeString("Id", Id);
      writer.WriteEndElement();
      //Second example xml element
      writer.WriteStartElement("Item2");
      writer.WriteAttributeString("Price", Price);
      writer.WriteAttributeString("Id", Id);
      writer.WriteAttributeString("Name", Name);
      writer.WriteEndElement();
    }
