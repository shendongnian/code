    class A : IDisposable
    {
    	public static A Instance {get; private set;}
    
        public static A()
        {
            Instance=new A();
        }
    
        public void MethodA() {...}
    
        public void Dispose()
        {
            //...
        }
    
        ~A()
        {
            // Release your hard resources here
        }
    }
