    [XmlRoot]
    public class Entity {
       [XmlIgnore]
       public IEnumerable<Foo> Foo { get; set; }
       [XmlElement]
       public List<Foo> FooSurrogate { get { return Foo.ToList() } set { Foo = value; } }
    }
