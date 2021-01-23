    public class Widget
    {
      // scope of 'latch'/what it represents is up to you.
      private static readonly object latch = new object() ;
      public void DoSomething()
      {
        DoSomethingReentrant() ;
        lock ( latch )
        {
           // nobody else may enter this critical section
           // (or any other critical section guarded by 'latch'
           // until you exit the body of the 'lock' statement.
           SerializedAccessDependentUponLatch() ;
        }
        DoSomethingElseReentrant() ;
        return ;
      }
    }
