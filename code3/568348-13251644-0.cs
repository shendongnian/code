    using System.Configuration;
    [Serializable]
    public class Result
    {
        [XmlAttribute, 
         DefaultValue("SomeString")]
        public string someString { get; set; }
        [XmlAttribute, 
         DefaultValue("SomeBool")]
        public bool someBool { get; set; }
        [XmlAttribute, 
         DefaultValue("SomeInt32")]
        public int someInt { get; set; }
        [XmlAttribute, 
         DefaultValue("SomeSingle")]
        public float someFloat { get; set; }
    }
