    class Prop {
        public string Str = "a string";
    }
    class A {
        Prop prop;
        protected A(Prop p) { prop = p; }
        public A() : this(new Prop()) { }
    }
    class B : A {
        Prop prop;
        private B(Prop p) : base(p) { prop = p; }
        public B() : this(new Prop()) { }
    }
    class C : B {
        public void Meth() {
            // has no access to prop.Str
        }
    }
