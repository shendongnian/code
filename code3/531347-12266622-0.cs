    // define root element
    [Serializable, XmlRoot("Person")]
    [XmlType(Namespace = "http://myschema.com")]
    public class Person
    {
        [XmlElement("firstname")]
        public string FirstName { get; set; }
        // define sub element
        [XmlElement("address")]  
        public Address address { get; set; }
    }
    [Serializable]
    [XmlType(Namespace = "http://myschema.com")]
    public class Address
    {
        [XmlElement("postcode")]
        public string Postcode { get; set; }
    }
