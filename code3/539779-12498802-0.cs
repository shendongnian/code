    public class A {
        public A1 {get;set;}
    }
    public class B : A {
        public new A1 {get;set;}
    }
    B b = new B();
    A a = b;
    
    a.A1; // references A.A1
    b.A1; // references B.A1
