    public class Consumer
    {
      private BlockingCollection<object> queue = new BlockingCollection<object>();
    
      public Consumer()
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              object item = queue.Take();
              DoSomethingWithItem(item);
            }
          });
        thread.Start();
      }
      public void QueueItem(object item)
      {
        queue.Add(item);
      }
    }
