    public class Person
    {
        [XmlElement]
        public string Name { get; set; }
    
        [XmlElement]
        public DateTime? BirthDate { get; set; }
    
        public bool BirthDateSpecified
        {
            get { return BirthDate.HasValue; }
        }
    }
