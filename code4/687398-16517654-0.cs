    public class SomeType // note DOES NOT INHERIT
    {
        private readonly List<SomeOtherType> items = new List<SomeOtherType>();
        public List<SomeOtherType> Items { get { return items; } }
        [XmlElement("mem3")] public string Mem3 {get;set;}
        [XmlElement("mem4")] public string Mem4 {get;set;}
    }
    public class SomeOtherType
    {
        [XmlElement("mem1")] public string Mem1 {get;set;}
        [XmlElement("mem2")] public string Mem2 {get;set;}
    }
