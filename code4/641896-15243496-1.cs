    public class Person
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlIgnore] // don't tell the stranger
        public Sex Sex { get; set; }
    }
