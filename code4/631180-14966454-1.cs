    public void AddWork(WorkToDo work)
    {
      queue.Add(work);
      lock(lockingObject)
      {
        signal.Set();
      }
    } 
