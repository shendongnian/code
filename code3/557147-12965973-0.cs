    public class Base {
        public string Foo () { return null; }
    }
    public class Inherited : Base {
        public new int Foo () { return 0; }
    }
