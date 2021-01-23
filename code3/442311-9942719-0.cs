    [Serializable]
    public class MyClass
    {
        [XmlAttribute]
        public bool myBool { get; set; }
        [XmlIgnore]
        public bool myBoolSpecified;
    }
