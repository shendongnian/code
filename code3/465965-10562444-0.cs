    [Serializable]
    public class Customer
    {
        [XmlElement("fname")]
        public string FirstName { get; set; }
        [XmlElement("lname")]
        public string LastName { get; set; }
    }
