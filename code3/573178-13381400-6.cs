    [Serializable]
    public class Result
    {
        [XmlAttribute]
        public int SomeInt { get; set; }
        
        [XmlIgnore]
        public bool SomeIntSpecified;
    }
