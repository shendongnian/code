    [Serializable]
    public class Name
    {
        [XmlAttribute]
        public string PropertyName { get; set; }
         [XmlAttribute]
        public string DisplayName { get; set; }
         [XmlAttribute]
        public int ListOrder { get; set; }
    }
    [Serializable]
    public class FullName
    {
        private Name strFirstName;
        [XmlElement("FirstName")]
        public Name FirstName
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }
        private Name strMiddleName;
        [XmlElement("MiddleName")]
        public Name MiddleName
        {
            get { return strMiddleName; }
            set { strMiddleName = value; }
        }
        private Name strLastName;
        [XmlElement("LastName")]
        public Name LastName
        {
            get { return strLastName; }
            set { strLastName = value; }
        }
        [XmlElement("ListOrder")]
        public int ListOrder { get; set; }
    }
  
    [Serializable]
    public class Visibility
    {
        public FullName FullName { get; set; }
        [XmlAttribute("DisplayName")]
        public String DisplayName { get; set; }
    }
  
    [Serializable]
    public class Visibilities
    {
        [XmlAttribute("AppName")]
        public String AppName { get; set; }
        [XmlElement("Visibility")]
        public List<Visibility> Visibility { get; set; }
    }
