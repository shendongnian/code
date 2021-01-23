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
        B(Prop p) : base(p = new Prop()) { prop = p; }
        public B() : this(null) { }
    }
    class C : B {
        public void Meth() {
            // has no access to prop.Str
        }
    }
