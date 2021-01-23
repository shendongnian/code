    public abstract class NamedBase
    {
        [XmlIgnore]
        public abstract string Name { get; set; }
    }
    
    public class NamedDerived : NamedBase
    {
        [XmlAttribute]
        public override string Name { get; set; }
    }
