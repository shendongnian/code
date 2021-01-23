    interface IA { void SomeMethodOnA(); }
    interface IB { void SomeMethodOnB(); }
    class A : IA { void SomeMethodOnA() { /* do something */ } }
    class B : IB { void SomeMethodOnB() { /* do something */ } }
    class C : IA, IB
    {
        private IA a = new A();
        private IB b = new B();
        void SomeMethodOnA() { a.SomeMethodOnA(); }
        void SomeMethodOnB() { b.SomeMethodOnB(); }
    }
