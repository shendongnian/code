    public class MyClass
    {
        private ISomeProvider someProvider;
    
        public ISomeProvider SomeProvider
        {
            get
            {
                //logic here 
                return this._someProvider;
            }
        }
    
        public MyClass(ISomeProvider someProvider)
        {
            this._someProvider = someProvider;
        }
    
        public void DoSomeWork()
        {
    
        }
    }
