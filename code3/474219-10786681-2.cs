    class A
    {
        protected virtual void method_impl(A a) { a.initialize(); }
        public A method() { A result = new A(); method_impl(result); return result; }
    }
    class B : A
    {
        public new B method() { B result = new B(); method_impl(result); return result; }
    }
    class C : B
    {
        public new C method() { C result = new C(); method_impl(result); return result; }
    }
