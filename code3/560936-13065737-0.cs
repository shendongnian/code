    interface I {
        void Method();
    }
    class C : I {
        void I.Method() { ... }
    }
    C c = new C();
    c.Method();      // won't compile
    ((I)c).Method(); // have to cast to I first
