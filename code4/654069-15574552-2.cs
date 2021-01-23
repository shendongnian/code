    class A 
    {
        // properties
        protected A(A other)
        {
            // copy properties
        }
        public A Clone()
        {
            A clone = CloneCore() as A;
            if (clone == null)
                throw new NotImplementedException("Clone Not Implemented Correctly");
            return clone;
        }
        protected virtual object CloneCore()
        {
            return new A(this);
        }
    }
    
