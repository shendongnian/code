    public class GraphViewModel
    {
        [XmlIgnore]
        public FooCollection Foos { get; set; }
        [XmlArray(ElementName = "Foos")]
        [XmlArrayItem(ElementName = "Foo")]
        public List<Foo> FoosSerializable
        {
            get
            {
                return this.Foos.ToList<Foo>();
            }
            set
            {
                this.Foos.AddRange(value);
            }
        }
    }
