    // We're going to define a class called Skill
    [Serializable()]
    public class Skill
    {
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }
    
        [System.Xml.Serialization.XmlElement("Mandatory")]
        public string Mandatory { get; set; }
    }
    [Serializable]
    [XmlRoot("CONTACTINFORMATION")]
    public class Contact
    {
       // ...... Rest of your elements
       [XmlArray("SkillSummary")]
       [XmlArrayItem("Skill", typeof(Skill))]
       public Skills[] Skill { get; set; }
    }
