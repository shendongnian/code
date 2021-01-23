    using System.ComponentModel;
    
    [Serializable]
    [XmlRoot("Settings")]
    public class UserSettings
    {
        [DefaultValue("Yogesh")]
        [XmlElement("User")]
        public string User { get; set; }
    
        [DefaultValue("1st")]
        [XmlElement("Level")]
        public string Level { get; set; }
    
    }
