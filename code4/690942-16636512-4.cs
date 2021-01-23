    public void FillBuffer() {
      while(!done) {
        lock(WorkItemsSyncRoot) {
          if(workitems.Count < 30) {
            workitems.Enqueue(new WorkItem(/* load a file or something */ ));
          }
        }
        System.Threading.Thread.Sleep(50);
      }
    }
