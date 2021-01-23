    public class AppSetting
    {
        [XmlAttribute("Name")]
        public string Name {get;set;}
        [XmlText()]
        public string AttributeValue {get;set;}
    }
