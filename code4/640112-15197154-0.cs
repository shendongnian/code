    public abstract class FooBar
    {
        public abstract string Foo { get; }
    
        public string GetTheFoo()
        {
            return "Here's the foo " + Foo;
        }
    }
