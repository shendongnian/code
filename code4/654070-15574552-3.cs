<!-- -->
    class B : A 
    {
        // one extra property
        protected B(B other) : base(other)
        {
            // copy extra property
        }
        public new B Clone()
        {
            B clone = CloneCore() as B;
            if (clone == null)
                throw new NotImplementedException("Clone Not Implemented Correctly");
            return clone;
        }
        protected override object CloneCore()
        {
            return new B(this);
        }
    }
