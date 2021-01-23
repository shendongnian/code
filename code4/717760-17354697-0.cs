    public class A<T> where T : B {
        public List<T> X { get; set; }
    }
    public class B {
    }
    public class C : B {
        string ExtraProperty { get; set; }
    }
    public class D : A<C> {
       // Property X is of type C.
    }
    public class E : A<B> {
       // Property X is of type B.
    }
