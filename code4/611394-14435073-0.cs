    [Serializable]
    [XmlRoot("Settings")]
    public class UserSettings
    {
        public UserSettings()
        {
            User = new DefaultableStringValue();
            Level = new DefaultableIntegerValue();
            IsFullscreen = new DefaultableBooleanValue();
        }
        [XmlElement("User")]
        public DefaultableStringValue User { get; set; }
        [XmlElement("Level")]
        public DefaultableIntegerValue Level { get; set; }
        [XmlElement("IsFullscreen")]
        public DefaultableBooleanValue IsFullscreen { get; set; }
    }
