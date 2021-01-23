    [Serializable]
    [XmlRoot("Path")]
    public class Brunch
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    
        [XmlElement(typeof(BinaryCortege), ElementName="Binary"),
            XmlElement(typeof(TextCortege), ElementName = "Text"),
            XmlElement(typeof(ExpandedTextCortege), ElementName = "ExpandText"),
            XmlElement(typeof(MultylineTextCortege), ElementName = "MultylineText"),
            XmlElement(typeof(IntCortege), ElementName = "DWord32"),
            XmlElement(typeof(LongCortege), ElementName="DWord64")]
        public List<Cortege> Corteges { get; set; }
    }
