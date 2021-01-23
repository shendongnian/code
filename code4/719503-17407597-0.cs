    abstract class Base {
        public Base(object o) { }
        public abstract void M();
    }
    class Derived : Base { 
       public Derived(object o) : base(o) { }
       public override void M() { } 
    }
