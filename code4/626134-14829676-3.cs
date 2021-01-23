    using Core;
    
    public class MyApi
    {
        private Core _coreInstance.... //some way of reaching Core, in other words
        public int Foo()
        {
            return _coreInstance.Foo();
        }
    }
