    XmlSerializer ser = new XmlSerializer(typeof(Settings));
    var result = (Settings)ser.Deserialize(stream);
    [XmlRoot("settings")]
    public class Settings
    {
        [XmlElement("app")]
        public Apps[] apps;
    }
        
    public class Apps
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("log")]
        public Logs[] Logs { get; set; }
    }
    public class Logs
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("path")]
        public string Path { get; set; }
        [XmlAttribute("filename")]
        public string Filename { get; set; }
    }
