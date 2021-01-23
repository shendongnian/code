    [Serializable]
    public class Foo
    {
        public Foo()
        {
            Bar = new List<Bar>();
        }
        [XmlArray("BarResponse")]
        [XmlArrayItem("Bar")]
        public List<Bar> Bar { get; set; }
    }
    [Serializable]
    public class Bar
    {
        [XmlAttribute("id")]
        public Int32 Id { get; set; }
    }
