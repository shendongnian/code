    public class Foo
    {
        private readonly object _syncObj = new object();
        public virtual void AbsFoo()
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
        protected override sealed  void doActualWork()
        {
            // do work.
           
        }
    }
    
