    public class MyClass : IDisposable
    {
        protected JTSEntities database = new JTSEntities();
    
        public void Dispose() 
        {
            database.Dispose();
        }
    }
    
    // When calling this class
    
    using(MyClass cls = new MyClass())
    {
        // Do Stuff
    }  // Dispose is automatically called here.
