    public class Base
    {
        private int foo = 5;
        protected int Foo { get { return foo; } }
    }
    
    public class Child : Base
    {
        protected new int Foo { get { return 0; } }
    }
    
    public class GrandChild : Child
    {
        // Aargh, can't get at the original Foo...
    }
