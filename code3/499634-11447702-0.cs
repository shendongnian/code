    public Class ActionableFoo : IFoo
    {
        Action _b1, b2;
        public ActionableFoo(Action b1, Action b2)
        {
            _b1 = b1;
            _b2 = b2;
        }
        public Bar1() { if(_b1 != null) b1(); }
        public Bar2() { if(_b2 != null) b2(); }
    }
