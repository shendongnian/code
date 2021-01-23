    //untested
    
    // the new definition
    private BlockingCollection<byte[]> ArrayAnsammlung = new BlockingCollection<byte[]>();
    
    
    while (aufnahme)
    {
       byte[] data = ArrayAnsammlung.Take();
    
       if (data != null)
       {
         int localNum = Interlocked.Increment(ref Nummerierung);  // initialize it 1 lower
          ... // process data
       }
    }
