    class A { }
    class B : A { public void BOnlyMethod() { } }
    class C : A { }
    public class Violations
    {
        private A a;
        public void DoIt()
        {
            Violate(out this.a);
        }
        void Violate(out B b)
        {
            b = new B();
            InnocentModification();
            // what we think is B, is now C in fact, yet we still can do this:
            b.BOnlyMethod();
            // which is bound to fail, as BOnlyMethod is not present on type C
        }
    
        void InnocentModification()
        {
            this.a = new C();
        }
    }
