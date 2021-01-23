    [Serializable, XmlRoot("model_data")]
    public class WeatherData
    {
        [XmlElement("site")]
        public City[] City { get; set; }
    }
    public class City
    {
        [XmlAttribute]
        public string a { get; set; }
    
        [XmlAttribute]
        public string b { get; set; }
    
        [XmlElement(ElementName="hour", IsNullable=true)]
        public Hour Hour { get; set; }
    }
    public class Hour 
    {    
        [XmlAttribute]
        public string x { get; set; }
    
        [XmlAttribute]
        public string y { get; set; }
    
        [XmlAttribute]
        public string z { get; set; }   
    }
