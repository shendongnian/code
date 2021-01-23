    TestXML obj = new TestXML{ attr1 = "Attrib1", attr2 = "Attrib2", DateAdded = DateTime.Now, TestElement = 44};
    
    XmlSerializer serializer = new XmlSerializer(typeof(TestXML));
    using (FileStream stream = new FileStream(@"C:\StackOverflow.xml", FileMode.OpenOrCreate))
    {
        serializer.Serialize(stream, obj);
    }
    
    using (FileStream stream = new FileStream(@"C:\StackOverflow.xml", FileMode.Open))
    {
        TestXML myxml = (TestXML)serializer.Deserialize(stream);
    }
