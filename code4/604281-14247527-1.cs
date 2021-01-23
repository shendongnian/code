    public class TestXML
    {
        [XmlElement("TestData")]
        public IntegerValue value { get; set; }
    }
    public class IntegerValue
    {
        public int value { get; set; }
        [XmlAnyAttribute]
        public XmlAttribute[] XAttributes { get; set; }
    }
    XmlSerializer serializer = new XmlSerializer(typeof(TestXML));
    using (FileStream stream = new FileStream(@"C:\StackOverflow.xml", FileMode.Open))
    {
        TestXML myxml = (TestXML)serializer.Deserialize(stream);
    }
