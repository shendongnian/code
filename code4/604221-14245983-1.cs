    [XmlRoot("TestXML")]
    public class TestXml {
        public TestElement te { get; set; }
    }
    
    public class TestElement {
        [XmlText]
        public int Value {get;set;}
        [XmlAttribute]
        public string attr1 {get;set;}
        [XmlAttribute]
        public string attr2 {get;set;}
    }
