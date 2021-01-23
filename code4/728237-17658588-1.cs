    [Serializable]
    [XmlRoot]
    public class Person
    {
        [XmlElement("Address")]
        public List<Address> Adresses { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set;}
    }
