    public class BaseClass {
        protected bool RunFoo2 { get; set; }
        public BaseClass() {
            // Not really needed, since booleans default to false
            RunFoo2 = false;
        }
        public virtual void foo1() {
            if (RunFoo2)
                foo2();
            // Default code here
        }
        public virtual void foo2() {
            // Whatever
        }
    }
    public class A : BaseClass {
        public A() : base() {
            RunFoo2 = true;
        }
    }
