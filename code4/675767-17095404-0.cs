    public class ConfigurationItem
    {
        public String Type { get; set; }
        public String Value { get; set; }
        [XmlAttribute("Label")]
        public string Label
        {
            get {return Value;}
            set {Value = value;}
        }
    }
