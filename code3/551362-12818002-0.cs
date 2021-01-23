    public class Class1<T> : IInterface<T>
        where T : Test2
    {
        public T Test { get; private set; }
    }
    public class Test2
    {
    }
    internal interface IInterface<T>
        where T : Test2
    {
        T Test { get; }
    }
