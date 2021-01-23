    public class action
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("occured")]
        public string occured { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlArray(typeof(session))]
        public ObservableCollection<session> session { get; set; }
    }
