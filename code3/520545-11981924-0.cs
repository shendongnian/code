    public class AttributeType
    {
        [XmlAttribute("size")]
        public int Size { get; set; }
    
        [XmlAttribute("decimal")]
        public bool IsDecimal { get; set; }
    
        [XmlAttribute("start_key")]
        public string StartKey { get; set; }
    
        [XmlAttribute("key")]
        public string Key { get; set; }
    
        [XmlAttribute("address")]
        public bool IsAddress { get; set; }
    
        [XmlAttribute("unbounded")]
        public bool IsUnbounded { get; set; }
    
        [XmlAttribute("end_key")]
        public int EndKey { get; set; }
    
        [XmlElement("convert")]
        public List<ConversionType> Converts { get; set; }
    
        [XmlElement("data_type")]
        public List<AttributeType> Types { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
