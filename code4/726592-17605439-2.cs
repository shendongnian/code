    public interface IClass1
    {
        string Foo1();
    }
    protected class Class1 : IClass1 { ... }
    public class Class2
    {
        ...
        public IClass1 Class1_Test { ... }
    }
