    public interface IMyInterface
    {
    ...
    }
    public class MyGenericClass<T> : IMyInterface
    {
    ....
    }
    IMyInterface myClass = new MyGenericClass<typeNeeded>();
