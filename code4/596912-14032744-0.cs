    System.Xml.Serialization.XmlSerializer writer =
        new System.Xml.Serialization.XmlSerializer(typeof(Word));
    System.IO.StreamWriter file = new System.IO.StreamWriter(
        fileName);
    writer.Serialize(file, Words);
