    public void RunTheseActionsInParallel(params Action[] TheActions)
    {
      List<Task> myTasks = new List<Task>(TheActions.Count);
      foreach(Action theAction in TheActions)
      {
        Task newTask = Task.Run(theAction);
        myTasks.Add(newTask);
      }
      foreach(Task theTask in myTasks)
      {
        theTask.Wait();
      }
    }
