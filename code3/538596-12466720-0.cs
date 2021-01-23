    public class Root
    {
        [XmlElement]
        public string Name { get; set; }
    
        [XmlElement]
        public string OtherValue { get; set; }
    
        [XmlElement("Shapes")]
        public ShapeContainer Shapes { get; set; }
    }
    
    public class ShapeContainer
    {
        [XmlAttribute]
        public string Name { get; set; }
    
        private readonly List<Shape> items = new List<Shape>();
        [XmlElement("Circle", typeof(Circle))]
        [XmlElement("Square", typeof(Square))]
        public List<Shape> Items { get { return items; } }
    }
    
    public class Shape
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class Circle : Shape
    {
        public string Whatever { get; set; }
    }
    
    public class Square : Shape
    {
        public string Something { get; set; }
    }
