    [XmlTypeAttribute]
    [XmlRootAttribute("RPM")]
    public class RPMConfiguration
    {
        [XmlElementAttribute("CAI")]
        public CAI[] CAIList{ get; set; }
    }
    [XmlTypeAttribute]
    public class CAI
    {
        [XmlAttributeAttribute("ID")]
        public int ID { get; set; }
        [XmlAttributeAttribute("Name")]
        public string Name { get; set; }
        [XmlAttributeAttribute("Active")]
        public string Active{ get; set; }
    }
