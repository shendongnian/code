    private ConcurrentDictionary<ulong, IFoo> openItems = new ConcurrentDictionary<ulong, IFoo>();
    private object locker = new object();
    public IFoo Open(ulong id)
    {
        var foo = this.openItems.GetOrAdd(id, x => nativeResource.Open(x));
            
        Interlocked.Increment(ref foo.RefCount);
            
        return foo;
    }
    public void Close(ulong id)
    {
        IFoo foo = null;
        if (this.openItems.TryGetValue(id, out foo))
        {
            Interlocked.Decrement(ref foo.RefCount);
            lock (this.locker)
            {
                if (foo.RefCount == 0)
                {
                    if (this.openItems.TryRemove(id, out foo))
                    {
                        this.nativeResource.Close(id);
                    }
                }
            }
        }
    }
