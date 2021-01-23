    public class C : IA, IB
    {
        private A _a;
        private B _b;
        public C()
        {
            this._a = new A();
            this._b = new B();
        }
        public void DoSomething()
        {
            this._a.DoSomething();
        }
        void IA.Calculate()
        {
            this._a.Calculate();
        }
        public void DoSomethingElse()
        {
            this._b.DoSomethingElse();
        }
        void IB.Calculate()
        {
            this._b.Calculate();
        }
    }
