    class Bar
    {
        private readonly IFoo _foo;
        public Bar(IFoo foo)
        {
            _foo = foo;
        }
        public DoSomething()
        {
            _foo.ExampleMethod(20)
        }
    }
