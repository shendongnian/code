    class Foo {
        public int M(string s) { return 0; }
        public string M(int s) { return String.Empty; }
    }
    Foo foo = new Foo();
    dynamic d = // something dynamic
    var m = foo.M(d);
