    public enum FooType
    {
        A,
        B,
        C
    }
    
    public class Foo
    {
        public FooType Type { get; private set; }
    
        // Option 1: forced via constructor
        public Foo(FooType type)
        {
            this.Type = type;
        }
    
        // Option 2: static properties
        // (using the constructor from option 1, can be done without it, though)
        public static Foo A { get { return new Foo(FooType.A); } }
        public static Foo B { get { return new Foo(FooType.B); } }
        public static Foo C { get { return new Foo(FooType.C); } }
    }
