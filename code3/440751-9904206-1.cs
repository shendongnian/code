    class FooLocker 
    { 
        ReaderWriterLockSlim locker = new ReaderWriterLockSlim(); 
        List<Foo> fooList = new List<Foo>(); 
 
        public void ChangeFoo(int index, string bar) 
        { 
            locker.EnterWriteLock(); 
     
            try 
            { 
                Foo foo = UnsafeGetFoo(index); 
                foo.Bar = bar; 
            } 
            finally 
            { 
                locker.ExitWriteLock(); 
            } 
        } 
     
        public Foo GetFoo(int index)  
        { 
            locker.EnterReadLock();  
     
            try 
            { 
    		    return UnsafeGetFoo(index);
            } 
            finally 
            { 
                locker.ExitReadLock(); 
            } 
        } 
     
    	private Foo UnsafeGetFoo(int index)
    	{
    		return fooList[index]; 
    	}
    } 
