    public interface ICommonInterface
    { }
    [InheritedExport]
    public abstract class CommonBaseClass<T> : ICommonInterface 
    { }
    public class Class1 : CommonBaseClass<Class1>
    { }
    public class Class2 : CommonBaseClass<Class2>
    { }
