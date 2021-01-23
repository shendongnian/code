    [XmlRoot("root")]
    [Serializable]
    public class RootElement
    {
        [XmlElement("prop1")]
        public string prop1 { get; set; }
	
        [XmlElement("prop2")]
        public string prop2 { get; set; }
	
        [XmlElement("data")]
        public DataElement data { get; set; }
    }
    [XmlRoot("data")]
    [Serializable]
    public class DataElement
    {
        [XmlElement("prop3")]
        public string prop3 { get; set; }
	
        [XmlElement("prop4")]
        public string prop4 { get; set; }
    }
    var yourObject = (RootElement)new XmlSerializer(typeof(RootElement)).Deserialize("your xml goes here");
