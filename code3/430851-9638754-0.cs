    public interface IFoo { }
    
    [Export(typeof(IFoo))]
    [Export("A", typeof(IFoo))]
    public class Foo1 : IFoo { }
    
    [Export(typeof(IFoo))]
    [Export("B", typeof(IFoo))]
    public class Foo2 : IFoo { }
