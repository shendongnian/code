    public class C : IA, IB
    {
        private A _a;
        private B _b;
        public C(A _a, B _b)
        {
            this._a = _a;
            this._b = _b;
        }
        public void methodA(int value) { _a.methodA(value); }
        public void methodB(int value) { _b.methodB(value); }
    }
