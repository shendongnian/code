    XmlSerializer mySerializer = new XmlSerializer(typeof(Speech));
    // Writing the file requires a TextWriter.
    TextWriter writer = new StreamWriter("test.xml");
    var speech = new Speech() { Id = 1, Language = "English", };
    mySerializer.Serialize(writer, speech);
    writer.Close();
