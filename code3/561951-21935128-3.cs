    public static void PriorityParallelForeach<T>(this IEnumerable<T> source, Action<T> action, ThreadPriority threadPriority, int? maxDegreeOfParallelism = null)
       {
           if (maxDegreeOfParallelism == null || maxDegreeOfParallelism<1)
           {
               maxDegreeOfParallelism = Environment.ProcessorCount;
           }
           var blockingQueue = new BlockingCollection<T>(new ConcurrentQueue<T>(source));
           blockingQueue.CompleteAdding();
            var tasks = new List<Task>() ;
            for (int i = 0; i < maxDegreeOfParallelism; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                 {
                     while (!blockingQueue.IsCompleted)
                     {
                         T item;
                         try
                         {
                             item = blockingQueue.Take();
                         }
                         catch (InvalidOperationException)
                         {
                             // collection was already empty
                             break;
                         }
                         action(item);
                     }
                 }, CancellationToken.None,
                      TaskCreationOptions.None,
                      new PriorityScheduler(threadPriority)));
            }
            Task.WaitAll(tasks.ToArray());
       }
