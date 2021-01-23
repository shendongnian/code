    [Serializable]
    public class CustomField
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("id")]
        public int Id { get; set; }
    
        [XmlElement("value")]
        public string Value { get; set; }
