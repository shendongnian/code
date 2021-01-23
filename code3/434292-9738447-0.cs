    abstract class B
    {
        protected B()
        {
            ...
        }
    
        protected B(object foo)
        {
            ...
        }
    }
    class D : B
    {
        public D() 
            : base() // not actually necessary, since it's called implicitly
        {
        }
    
        public D(object foo)
            : base(foo)
        {
        }
    }
