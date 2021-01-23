    public enum BaseType
    {
        ConcreteOne = 1,
        ConcreteTwo = 2
    }
    public abstract class Base
    {
       ...
       public BaseType BaseType { get; set; }
       ...
    }
