    public Class ActionableFoo : IFoo
    {
        Action _bar1, _bar2;
        public ActionableFoo(Action b1, Action b2)
        {
            _bar1 = b1;
            _bar2 = b2;
        }
        public void Bar1() { if(_bar1 != null) _bar1(); }
        public void Bar2() { if(_bar2 != null) _bar2(); }
    }
