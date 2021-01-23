    public class Foo : IFoo
    {
        private readonly static Foo instance = new Foo();
        private Foo() { }
        public static Foo Instance
        {
            get { return Foo.instance; }
        }
        // IFoo member:
        public void InterfaceFoo()
        {
            Foo.LegacyFoo();
        }
        public static void LegacyFoo()
        {
            // Implementation goes here...
        }
    }
