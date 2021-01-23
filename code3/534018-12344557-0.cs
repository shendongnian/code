    using System.Xml.Serialization;
    ...
    [XmlRoot("UPDs")]
    public class UDPCollection
    {
        // XmlSerializer cannot serialize List. Changed to array.
        [XmlElement("UPD")]
        public UDP[] UDPs { get; set; }
        [XmlAttribute("LUPD")]
        public int LUPD { get; set; } 
        public UDPCollection()
        {
            // Do nothing
        }
    }
    [XmlRoot("UPD")]
    public class UDP
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlElement("ER")]
        
        public ER[] ERs { get; set; }
        // Need a parameterless or default constructor.
        // for serialization. Other constructors are
        // unaffected.
        public UDP()
        {
        }
        // Rest of class
    }
    [XmlRoot("ER")]
    public class ER
    {
        [XmlAttribute("R")]
        public string LanguageR { get; set; }
        // Need a parameterless or default constructor.
        // for serialization. Other constructors are
        // unaffected.
        public ER()
        {
        }
        // Rest of class
    }
