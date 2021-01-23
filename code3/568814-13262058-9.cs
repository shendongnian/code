        if (item == null)
        {
            lock (_locker)
            {
                if (item == null)
                {
                    var temp = new Something();
                    // Insure all writes used to construct new value have been flushed.
                    System.Threading.Thread.MemoryBarrier();                     
                    item = temp;
                }
            }
        }
    The processor executing the current thread cannot reorder instructions in such a way that memory accesses prior to the call to `MemoryBarrier` execute  after memory accesses that follow the call to `MemoryBarrier`.
