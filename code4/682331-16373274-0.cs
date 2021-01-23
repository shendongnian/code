    class Ancestor
    {
        public virtual int DoSomething()
        {
            // execute commands here.
            // for now just throw exception.
            throw new NotImplementedException();
        }
    }
    
    class Derived_A : Ancestor
    {
        public override int DoSomething()
        {
            return 1 + 1;
        }
    }
    
    class Derived_B : Ancestor
    {
        public override int DoSomething()
        {
            return 1 + 2;
        }
    }
