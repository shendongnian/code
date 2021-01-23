    public class A {
        public A() {
            // Default constructor
        }
        public A(A other) {
            // Copy-constructor. Members of other will be copied into this instance.
        }
    }
    
    public class B : A {
        public B() {
        }
        public B(A other) : base(other) { // Notice how it calls the parent class's copy-constructor too
        }
    }
