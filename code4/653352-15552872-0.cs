    class Child : Parent
    {
        void SomeMethod()
        {
            base.MethodToCall();
        }
    }
    
    class Parent
    {
        protected void MethodToCall()
        {
           // protected methods are accesible from
           // descendants and private from outside
        }
    }
