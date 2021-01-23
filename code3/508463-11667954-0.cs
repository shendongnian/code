    class MyTaskFactory
    {
      public virtual void CreateTask(Action a)
      {
        Task.Factory.StartNew(a);
      }
    }
