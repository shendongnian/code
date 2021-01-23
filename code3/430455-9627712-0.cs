    class Derived : IMethod
    {
        private IMethod baseObject = new Base();
    
        void DoWork()
        {
            baseObject.DoWork();
            
            // Custom DoWork code here
        }
    }
