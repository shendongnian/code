    class Program
    {
      private static QueuedTaskScheduler queueScheduler = new QueuedTaskScheduler(targetScheduler: TaskScheduler.Default, maxConcurrencyLevel: 1);
      private static TaskScheduler ts_priority1;
      private static TaskScheduler ts_priority2;
      private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
      static void Main(string[] args)
      {
        ts_priority1 = queueScheduler.ActivateNewQueue(1);
        ts_priority2 = queueScheduler.ActivateNewQueue(2);
        QueueValue(1, ts_priority2);
        QueueValue(2, ts_priority2);
        QueueValue(3, ts_priority2);
        QueueValue(4, ts_priority1);
        QueueValue(5, ts_priority1);
        QueueValue(6, ts_priority1);
        Console.ReadLine();           
      }
      private static Task QueueTask(Func<Task> f, TaskScheduler ts)
      {
        return Task.Factory.StartNew(f, CancellationToken.None, TaskCreationOptions.HideScheduler | TaskCreationOptions.DenyChildAttach, ts).Unwrap();
      }
      private static Task QueueValue(int i, TaskScheduler ts)
      {
        return QueueTask(async () =>
        {
          await semaphore.WaitAsync();
          try
          {
            Console.WriteLine("Start {0}", i);
            await Task.Delay(1000);
            Console.WriteLine("End {0}", i);
          }
          finally
          {
            semaphore.Release();
          }
        }, ts);
      }
    }
