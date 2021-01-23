    class C : A, IB
    {
        private B _b = new B();
        // IB members
        public void SomeMethod()
        {
            _b.SomeMethod();
        }
    }
