    public class Foo
    {
        private IMyClassFactory _factory;
    
        public Foo(IMyClassFactory factory)
        {
            _factory = factory;
        }
    
        public bool Method(IMyClass myObj)
        {
            if (myObj != null)
                return true;       
                
            return _factory.CreateMyClass().SomeFunctionReturningBool();
        }
    }
