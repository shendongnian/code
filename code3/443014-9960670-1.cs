    public class MyClass : ChildClass, IDisposable
    {
        MyPoolManager manager = null;
    
        public MyClass(MyPoolManager manager)
        {
            this.manager = manager;
    
        }
        
        public void Dispose()
        {
            manager.ReturnPooledConnection(this);
            base.Dispose();
        }
    }
