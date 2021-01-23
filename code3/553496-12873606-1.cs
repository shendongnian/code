    XmlSerializer _serializer = new XmlSerializer(typeof(XMLExample));
    XMLExample _example = new XMLExample();
    // Read file.
    using (TextReader textReader = new StreamReader(@"C:\test\testserialization.xml"))
    {
        _example = (XMLExample)_serializer.Deserialize(textReader);
        textReader.Close();
    }
    // Populate user interface from the class.
    // ...
    // Populate class from user interface
    _example.Details.Add(new Detail() { FirstName = "John", LastName = "Doe" });
    _example.Details.Add(new Detail() { FirstName = "Jane", LastName = "Doe" });
    // Write file.
    using (TextWriter textWriter = new StreamWriter(@"C:\test\testserialization.xml"))
    {
        _serializer.Serialize(textWriter, _example);
        textWriter.Close();
    }
