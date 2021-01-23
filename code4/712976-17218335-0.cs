    public interface ISpecialObjectCreateable { ... }
 
    public MyClassA : ISpecialObjectCreateable { ... }
 
    public MyClassB : ISpecialObjectCreateable { ... }
    public class SpecialObject
    {
        public SpecialObject(ISpecialObjectCreatable createable)
        {
           ...
        }
    }
