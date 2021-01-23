    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(t1.GetType());
    StringWriter sww = new StringWriter();
    XmlWriter writer = XmlWriter.Create(sww);
    x.Serialize(writer, t1);
    var xml = XDocument.Parse(sww.ToString());
    Console.WriteLine(xml.Root);
