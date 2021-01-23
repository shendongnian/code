    public class xml
    {
        [XmlElement("OrgUnit")]
        public OrgUnit[] OrgUnits { get; set; }
    }
    
    public class OrgUnit
    {
        [XmlAttribute]
        public int GUID { get; set; }
    
        [XmlElement("OrgUnit")]
        public OrgUnit[] OrgUnits { get; set; }
    }
