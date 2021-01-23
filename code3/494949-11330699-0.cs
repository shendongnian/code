    [Serializable]  
    public class SerializationClass
    {
        public SerializationClass(string value)
        {
            this.Value = value;
        }
        [XmlAttribute("value")]
        public string Value { get; }
    }
    [Serializable]                     
    public class SomeModel                     
    {                     
        [XmlIgnore]                     
        public string SomeString { get; set; }                     
                         
        [XmlIgnore]                      
        public int SomeInfo { get; set; }  
        [XmlElement]
        public SerializationClass SomeStringElementName
        {
            get { return new SerializationClass(this.SomeString); }
        }               
    }
