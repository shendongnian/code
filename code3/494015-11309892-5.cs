    public interface IA
    { }
    public interface IB
    {
        MyInterface<IA> SomeGetter { get; }
    }
    public class A : IA
    { }
    public interface MyInterface<out T>
        where T : IA
    { }
    public class MyClass<T> : MyInterface<T> where T : IA
    { }
    public class SomeClass : IB
    {
        public MyInterface<IA> SomeGetter
        {
            get { return new MyClass<A>(); }
        }
    }
