    [Serializable()]
    [XmlRoot(ElementName = "lfm", IsNullable = true)]
    public class fm
    {
        [XmlElement("track")]
        public Track lfm { get; set; }
    }
