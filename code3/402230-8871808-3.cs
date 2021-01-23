    public class Foo {
        private String _fooName;
        private String _barName;
        public String FooName { get { return _fooName.ToUpper(); } set { _fooName = value; } }
        // This breaks FooReader because you changed a field to a property
        public String BarName { get { return _barName.ToUpper(); } set { _barName = value; } }
    }
