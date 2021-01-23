    [XmlRoot("Method")]
    public class MyMethod
    {
        [XmlAttribute]
        public String Name   { get; set; }
        [XmlElement]
        public int DEF   { get; set; }
    }
    [XmlRoot("Request", Namespace="http://mynamespace")]
    public class MyRequest
    {
        [XmlElement]
        public String ABC { get; set; }
        [XmlElement(Namespace="http://myothernamespace")]
        public MyMethod Method { get; set; }
    }
