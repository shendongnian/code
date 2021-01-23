    class Derived : IMethod
    {
        private class SneakyBase : Base
        {
            // abstract implementations here
        }
        private IMethod baseObject = new SneakyBase();
    
        void DoWork()
        {
            baseObject.DoWork();
            
            // Custom DoWork code here
        }
    }
