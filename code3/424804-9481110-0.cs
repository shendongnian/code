    [XmlRoot]
    public class ExampleCol
    {
    
        [XmlText] // Here !!
        public ElementWithAttribute ewa1 {get;set}
    
        [XmlElement("AnotherCol")]
        public AnotherCol ac1 {get;set}
    
    
    }
