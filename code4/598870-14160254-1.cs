    using System.Windows.Threading; // WPF Dispatcher from assembly 'WindowsBase'
 
    public static void RunInWpfSyncContext( Func<Task> function )
    {
      if (function == null) throw new ArgumentNullException("function");
      var prevCtx = SynchronizationContext.Current;
      try
      {
        var syncCtx = new DispatcherSynchronizationContext();
        SynchronizationContext.SetSynchronizationContext(syncCtx);
        var task = function();
        if (task == null) throw new InvalidOperationException();
        var frame = new DispatcherFrame();
        var t2 = task.ContinueWith(x=>{frame.Continue = false;}, TaskScheduler.Default);
        Dispatcher.PushFrame(frame);   // execute all tasks until frame.Continue == false
        task.GetAwaiter().GetResult(); // rethrow exception when task has failed 
      }
      finally
      { 
        SynchronizationContext.SetSynchronizationContext(prevCtx);
      }
    }
