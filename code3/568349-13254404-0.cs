    [Serializable]
    public class Result
    {
        [XmlAttribute]
        public string someString { get; set; }
        [XmlAttribute]
        public bool? someBool { get; set; }
        [XmlAttribute]
        public int? someInt { get; set; }
        [XmlAttribute]
        public float? someFloat { get; set; }
    }
