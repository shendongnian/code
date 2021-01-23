    interface IFoo {
        bool Bar { get; }
        string Name { get; }
        int Fooby { get; }
    }
    public class Foo : IFoo {
        ...
        public static readonly IFoo SomePrototype = new Foo
        {
            Bar = false,
            Name = "Generic False State",
            Fooby = -1
        };
        public static readonly IFoo SomeOtherPrototype = new Foo
        {
            Bar = true,
            Name = "Generic True State",
            Fooby = Int32.MaxValue
        };
        ...
    }
