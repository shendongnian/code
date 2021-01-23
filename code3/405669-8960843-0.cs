    public class Configuration
    {
        public Certification Configs { get; set; }
    }
    
    public class Certification
    {
        [XmlArray("Certification")]
        [XmlArrayItem("name")]
        public string[] name { get; set; }
    
        public Path[] Services { get; set; }
    }
