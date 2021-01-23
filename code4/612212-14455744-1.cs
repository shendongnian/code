    [Guid("000208D5-0000-0000-C000-000000000046")] // Anything
    [CoClass(typeof(Foo))]
    [ComImport]
    public interface IFoo { void Bar(); }
     
    public class Foo : IFoo { public void Bar() { return; } }
    void Main()
    {
        IFoo instance = new IFoo();
    }
