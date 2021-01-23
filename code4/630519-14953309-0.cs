    [DataContract]
    public class Shape { }
    
    [DataContract]
    public class Rectangle : Shape { }
    
    [DataContract]
    public class Square : Shape { }
    [ServiceContract]
    [ServiceKnownType(typeof(Rectangle))]
    [ServiceKnownType(typeof(Square))]
    public interface IService
    {
        [OperationContract]
        Shape[] GetShapes();
    }
    public class Service : IService
    {
        [OperationBehavior]
        public Shape[] GetShapes()
        {
            return new Shape[] {
                new Square(),
                new Rectangle()
            };
        }
    }
