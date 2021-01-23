    [Serializable()]
    public class Person
    {
        [System.Xml.Serialization.XmlElementAttribute("first-name")]
        public string FirstName{ get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute("last-name")]
        public string LastName{ get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute("headline")]
        public string Headline{ get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute("site-standard-profile-request")]
        public string ProfileRequest{ get; set; }
    }
