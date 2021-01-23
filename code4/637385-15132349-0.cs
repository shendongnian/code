    public class Folders
    {
        public string Id { get; set; }
        [XmlElement("Folders")]
        public List<Folders> ListFolder { get; set; }
    }
