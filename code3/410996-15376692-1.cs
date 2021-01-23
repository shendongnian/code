    [XmlRoot]
    public class Entity {
       [XmlIgnore]
       public IEnumerable<Foo> Foo { get; set; }
       [XmlElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
       public List<Foo> FooSurrogate { get { return Foo.ToList() } set { Foo = value; } }
    }
