    class Foo
    {
        public Foo() {}
        // Break the dependency cycle by promoting IBar to a property.
        public IBar Bar { get; set; }
    }
    class Bar
    {
        public Bar(IFoo foo) {}
    }
