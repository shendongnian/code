    // Task Provider - basically, construct your first call as appropriate, and then 
    //   invoke this on state change
    public void OnStateChanged()
    {
        if(_cts != null)
           _cts.Cancel();
        _cts = new CancellationTokenSource();
        _task = Task.Factory.StartNew(() =>
           {
               // Do Computation, checking for cts.IsCancellationRequested, etc
               return result;
           });
    }
    // Consumer 1
    var cts = new CancellationTokenSource();
    var task = Task.Factory.StartNew(() =>
      {
           var waitForResultTask = Task.Factory.StartNew(() =>
              {
                  // Internally, this is invoking the task and waiting for it's value
                  return MyApplicationState.GetComputedValue();
              });
           // Note this task cares about being cancelled, not the one above
           var cancelWaitTask = Task.Factory.StartNew(() =>
             {
                  while(!cts.IsCancellationRequested)
                     Thread.Sleep(25);
             });
           Task.WaitAny(waitForResultTask, cancelWaitTask);
           if(cancelWaitTask.IsCancelled)
              return "Blah"; // I cancelled waiting on the original task, even though it is still waiting for it's response
           else
              return waitForResultTask.Result;
      });
