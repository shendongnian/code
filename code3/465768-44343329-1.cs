       public TaskScheduler TaskScheduler
        {
          get { return taskScheduler ?? (taskScheduler = TaskScheduler.Current); }
          set { taskScheduler = value; }
        }
    
        public TaskScheduler TaskSchedulerUI
        {
          get { return taskSchedulerUI ?? (taskSchedulerUI = TaskScheduler.FromCurrentSynchronizationContext()); }
          set { taskSchedulerUI = value; }
        }
      public Task Update()
        {
          IsBusy = true;
          return Task.Factory.StartNew( () =>
                     {
                       LongRunningTask( );
                     }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler )
                     .ContinueWith( t => IsBusy = false, TaskSchedulerUI );
        }
