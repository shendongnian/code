    public class Consumer
    {
      private BlockingCollection<Action> queue = new BlockingCollection<Action>();
    
      public Consumer()
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              Action method = queue.Take();
              method();
            }
          });
        thread.Start();
      }
      public void BeginInvoke(Action method)
      {
        queue.Add(item);
      }
    }
