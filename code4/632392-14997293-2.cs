    public class Foo
    {
        private readonly object _syncObj = new object();
        public void AbsFoo()
        {
           lock(syncObj )
           {
              doActualWork();
           }
        }
        
        protected abstract void doActualWork();
    }
    
    public class Bar : Foo
    {
        protected override void doActualWork()
        {
            // do work.
           
        }
    }
    
