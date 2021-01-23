    [XmlRoot("person")]
    [Serializable()]
    public class LinkedIn
    {
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("last-name")]
        public string LastName { get; set; }
        [XmlElement("headline")]
        public string Headline { get; set; }
        public StandardProfile Profile { get;set; }
    }
