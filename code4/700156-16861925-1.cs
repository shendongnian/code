    class B : IB
    {
        public int fun()
        {
            A a = this.CreateA();
            ...
        }
        protected A CreateA() { return new A(); }
    }
