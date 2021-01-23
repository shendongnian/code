    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        reader.ReadStartElement();
        Name = reader.ReadElementString("Name");
        Age = Convert.ToInt32(reader.ReadElementString("Age"));
        var xmlSerializer = new XmlSerializer(typeof (Address));
        Address = (Address) xmlSerializer.Deserialize(reader);
        reader.ReadEndElement();
    }
