    [XmlRoot("ConfigurationMap")]
    public class ConfigurationMap
    {
        [XmlArray("mapConfig")]
        [XmlArrayItem("entry")]
        public List<Entry> MapConfig { get; set; }
    }
    [XmlRoot("entry")]
    public class Entry
    {
        [XmlElement("string")]
        public List<string> entry { get; set; }
    }
