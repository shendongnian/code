    [XmlRoot("map")]
    public class MyMap
    {
        [XmlAttribute("version")]
        public decimal Version { get; set; }
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<MyProperty> Properties { get; set; }
    }
