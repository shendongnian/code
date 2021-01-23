    XmlDocument doc = new XmlDocument();
    System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(Patients.GetType());
    System.IO.MemoryStream stream = new System.IO.MemoryStream();
    serializer2.Serialize(stream, Patients);
    stream.Position = 0;
    doc.Load(stream);
