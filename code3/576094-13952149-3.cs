    protected override void OnStop()
    {
      int timeout = 10000;
      var task = Task.Factory.StartNew(() => MyTask());
      while (!task.Wait(timeout))
      {
          RequestAdditionalTime(timeout);
      }
    }
