    class Workflow<T>
        where T: class
    {
        private readonly T _someObject;
    
        public Workflow(T someObject)
        {
            _someObject = someObject;
        }
    
    
        public void func() 
        {
             func2(1);
             func3("string");
             func4(new MyObject());
        } 
    
        private void func2(int a) 
        {
            // use _someObject here
        }
    
        private void func3(string s) 
        {
            // ...
        }
    }
    
    // usage
    var flow = new Workflow(someObject);
    flow.f();
