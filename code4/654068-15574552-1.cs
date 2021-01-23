<!-- -->
    class B : A 
    {
        // one extra property
        protected B(B other) : base(other)
        {
            // copy extra property
        }
        public new B Copy()
        {
            return new B(this);
        }
    }
