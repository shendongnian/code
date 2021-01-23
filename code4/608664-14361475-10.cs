    public class AppSetting
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlIgnore()]//Why Do This?  XmlSerializer doesn't allow you to specify the Object type as XmlText, you have to use a primitive or string.
        public object Value { get; set; }
        [XmlText()]
        public string AttributeValue
        {
            get
            {
                return Value.ToString();
            }
            set
            {
                ;//do nothing
            }
        }
    }
