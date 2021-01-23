    public class YourForm : Form
    {
      private ConcurrentQueue<ResultContainer> results = new ConcurrentQueue<ResultContainer>();
    
      public UpdateTimer_Tick(object sender, EventArgs args)
      {
        // Limit the number of results to be processed on each cycle so that
        // UI does not stall for too long.
        int maximumResultsToProcessInThisBatch = 100;
    
        ResultContainer result;
        for (int i = 0; i < maximumResultsToProcessInThisBatch; i++)
        {
          if (!results.TryDequeue(out result)) break;
          UpdateUiControlsHere(result);
        }
      }
    
      private void WorkerThread()
      {
        while (true)
        {
          // Do work here.
          var result = new ResultContainer();
          result.Item1 = /* whatever */;
          result.Item2 = /* whatever */;
          // Now publish the result.
          results.Enqueue(result);
        }
      }
    }
