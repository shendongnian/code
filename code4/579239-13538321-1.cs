    public class Foo
    {
        public Foo (ILogger logger) { /* some implementation here */ }
    }
    public class Bar : Foo
    {
        public Bar(ILogger logger)
            : base(logger)
        {
            // some implementation here
        }
    }
