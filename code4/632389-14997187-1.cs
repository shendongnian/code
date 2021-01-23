    public class Foo
    {
        private readonly object _syncRoot = new object();
    
        public void AbsFoo()
        {
            // You can do more here, like some logging
            lock(_syncRoot)
            {
                AbsInternal();
            }
        }
    
        protected abstract void AbsInternal();
    }
    public class Bar : Foo
    {
        protected override void AbsInternal()
        {
            // do work.
            // Note: No call to base.AbsInternal(); or base.AbsFoo(); here
        }
    }
