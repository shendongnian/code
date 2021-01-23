    public class Foobar
    {
      private Int32 _isFrozen;
      private Int32 _writers;
      public void Freeze()
      { 
         Interlocked.Exchange(ref _isFrozen, 1); 
         // Wait for the writers to exit
         while (Interlocked.CompareExchange(ref _writers, 0, 0) != 0)
            Thread.Yield();
      }
      public void WriteValue(Object val)
      {
         if (Interlocked.CompareExchange(ref _isFrozen, 0, 0) == 1)
            throw new InvalidOperationException();
         Interlocked.Increment(ref _writers);
         try
         {
            if (Interlocked.CompareExchange(ref _isFrozen, 0, 0) == 1)
               throw new InvalidOperationException();
            // write ...
         }
         finally
         {
            Interlocked.Decrement(ref _writers);
         }
      }
    }
