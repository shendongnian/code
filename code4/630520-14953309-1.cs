    [DataContract]
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Shape))]
    public class Shape { }
    
    [DataContract]
    public class Rectangle : Shape { }
    
    [DataContract]
    public class Square : Shape { }
