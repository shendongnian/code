    [Serializable]
    [XmlRoot("Settings")]
    public class UserSettings
    {
        [XmlElement("User")]
        [DefaultValue("Programmer")]
        public string User { get; set; }
    
        [XmlElement("Level")]
        [DefaultValue(2)]
        public string Level { get; set; }
    
    }
