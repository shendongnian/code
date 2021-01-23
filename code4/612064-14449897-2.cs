    public void RunTheseActionsInParallel(params Action[] TheActions)
    {
      List<Task> myTasks = new List<Task>(TheActions.Count);
      foreach(Action theAction in TheActions)
      {
        Task theTask = Task.Run(theAction);
      }
      foreach(Task theTask in myTasks)
      {
        theTask.Wait();
      }
    }
