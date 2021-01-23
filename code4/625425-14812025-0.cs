    public class Computers {
        private readonly List<Computer> items = new List<Computer>();
        [XmlElement("Computer")]
        public List<Computer> Items { get { return items; } }
        [XmlAttribute("StorageType")]
        public int StorageType { get; set; }
        [XmlAttribute("StorageName")]
        public string StorageName { get; set; }   
    }
