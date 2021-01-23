    class A
    {
        public A Clone()
        {
            return CloneImpl();
        }
    
        protected virtual A CloneImpl()
        {
            return MemberwiseClone();
        }
    }
    
    class B : A
    {
        new public B Clone()
        {
            return (B)CloneImpl();
        }
    }
