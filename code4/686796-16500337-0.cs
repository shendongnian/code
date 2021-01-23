    public class MyModel
    {
        [XmlIgnore]
        public bool Foo 
        {
            get
            {
                return string.Equals(FooXml, "true", StringComparison.OrdinalIgnoreCase);
            }
            set
            {
                FooXml = value.ToString();
            }
        }
    
        [XmlElement("Foo")]
        public string FooXml { get; set; }
    }
