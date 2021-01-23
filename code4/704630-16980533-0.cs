    public interface I1 { }
    public interface IBaseClass<out U> : IEnumerable<U> where U : I1 { }
    public class Class1 : I1 { }
    public class DerivedClass : IBaseClass<Class1>
    {
    }
