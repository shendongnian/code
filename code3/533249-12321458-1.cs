    TestMethod1 : FailedTest method TestProject1.UnitTest1.TestMethod1 threw exception: 
    System.InvalidOperationException: There is an error in XML document (1, 5). ---> System.InvalidOperationException: <home xmlns=''> was not expected.
    at Microsoft.Xml.Serialization.GeneratedAssembly.XmlSerializationReaderBaseModel.Read3_BaseModel()
    --- End of inner exception stack trace ---
    at System.Xml.Serialization.XmlSerializer.Deserialize(XmlReader xmlReader, String encodingStyle, XmlDeserializationEvents events)
    at System.Xml.Serialization.XmlSerializer.Deserialize(XmlReader xmlReader, String encodingStyle)
    at System.Xml.Serialization.XmlSerializer.Deserialize(TextReader textReader)
    at TestProject1.UnitTest1.TestMethod1() in UnitTest1.cs: line 26
