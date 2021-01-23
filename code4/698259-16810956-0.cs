    public class PeopleWrapper
    {
        [XmlAttribute("someValue")]
        public int SomeValue { get; set; }
    
        private readonly List<Person> people = new List<Person>();
        [XmlElement("person")]
        public List<Person> Items { get { return people; } }
    }
