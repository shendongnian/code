    using (XmlWriter writer = XmlWriter.Create("test.x))
    {
       writer.WriteStartElement("Order");
       writer.WriteAttributeString("key", "value");
       writer.WriteEndElement();
    }
