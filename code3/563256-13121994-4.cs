    [XmlRoot("Foo")]
    public class Foo
    {
        public Foo()
        {
            Bars= new List<Bar>();
        }
        [XmlArray("BarResponses")]
        [XmlArrayItem(typeof(Bar))]
        public List<Bar> Bars { get; set; }
        //some other elements go here.
    }
    
    
    [XmlRoot("Bar")]
    public class Bar
    {
        [XmlAttribute("id")]
        public Int32 Id { get; set; }
        //some other elements go here.
    }
