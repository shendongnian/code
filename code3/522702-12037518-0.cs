       public static class UiScheduler
       {
          private static TaskScheduler _scheduler;
          private static readonly ConcurrentQueue<Action> OldActions = new ConcurrentQueue<Action>();
    
          public static void InitializeUiContext()
          {
             _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
          }
    
          private static void ExecuteOld()
          {
             if(_scheduler != null)
             {
                while(OldActions.Count > 0)
                {
                   Action a;
                   
                   if(OldActions.TryDequeue(out a))
                   {
                      UiExecute(_scheduler, a);
                   }
                }
             }
          }
    
          private static void UiExecute(TaskScheduler scheduler, Action a, bool wait = false)
          {
             if (Thread.CurrentThread.ManagedThreadId == 1)  //1 is usually UI thread, dunno how to check this better
             {
                a();
             }
             else
             {
                Task t = Task.Factory.StartNew(a, CancellationToken.None, TaskCreationOptions.LongRunning, scheduler);
    
                if (wait) t.Wait();
             }         
          }
    
          public static void UiExecute(Action a, bool wait = false)
          {
             if (a != null)
             {
                if (_scheduler != null)
                {
                   ExecuteOld();
    
                   UiExecute(_scheduler, a, wait);
                }
                else
                {
                   OldActions.Enqueue(a);
                }
             }
          }
       }
