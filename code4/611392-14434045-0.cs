    [Serializable]
    [XmlRoot("Settings")]
    public class UserSettings
    {
        [XmlElement("User")]
        public DefaultableValue User { get; set; }
        [XmlElement("Level")]
        public DefaultableValue Level { get; set; }
    }
    [Serializable]
    public class DefaultableValue
    {
        [XmlAttribute("default")]
        public string Default { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
