    public class Base { 
        public string Foo () { return null; }
    }
    public class Inherited : Base {
        public new string Foo () { return "Something else..."; }
    }
