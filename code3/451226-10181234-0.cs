    public class Foo
    {
       protected static readonly object _locker = new object();
    }
    
    public class Foo<T> : Foo
    {
        public void FooMethod(object stateInfo)
        {        
            if (!Monitor.TryEnter(_locker)) { return; }
    
            try
            {
                // Logic here
            }
            finally
            {
                Monitor.Exit(_locker);
            }
        }
    }
