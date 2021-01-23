    class A { public int Foo { get; set; } }
    class B {
        public int Foo { get; set; }
        static Random rg = new Random();
        static explicit operator A(B b) {
            return new A { Foo = b.Foo; }
        }
    }
