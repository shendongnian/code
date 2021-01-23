    static void Main(string[] args)
    {
      // ...
      for (int i = 0; i < 10; i++)
      {
        var dtx = Transaction.Current.DependentClone(
            DependentCloneOption.BlockCommitUntilComplete);
        tasks[i] = TestStuff(dtx);
      }
      //...
    }
    static async Task TestStuff(DependentTransaction dtx)
    {
        using (var ts = new TransactionScope(dtx))
        {
            // do transactional stuff
    
            ts.Complete();
        }
        dtx.Complete();
    }
