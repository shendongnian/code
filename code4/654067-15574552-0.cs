    class A 
    {
        // properties
        protected A(A other)
        {
            // copy properties
        }
        public A Copy()
        {
            return new A(this);
        }
    }
    
