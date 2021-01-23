    public class Employee
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("field")]
        public List<Field> Fields { get; set; }
        public string DisplayName 
        { 
            get 
            {
                return Fields.Where(i => i.Id == "displayName").FirstOrDefault().Value;
            } 
        }
        public string Email
        {
            get
            {
                return Fields.Where(i => i.Id == "email").FirstOrDefault().Value;
            }
        }
    }
    public class Field
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
