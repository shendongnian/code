    [Guid("000208D5-0000-0000-C000-000000000046")] // Anything
    [CoClass(typeof(Foo))]
    public interface IFoo { void Bar(); }
     
    public class Foo : IFoo { void Bar() { return; } }
    void main()
    {
        IFoo instance = new IFoo();
    }
