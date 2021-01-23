    public class WorkItem { 
      // populate with something usefull
    }
    
    public static object WorkItemsSyncRoot = new object();
    public static Queue<WorkItem> workitems = new Queue<WorkItem>();
    
    public void FillBuffer() {
      while(!done) {
        lock(WorkItemsSyncRoot) {
          if(workitems.Count < 30) {
            workitems.Enqueue(new WorkItem(/* load a file or something */ ));
          }
        }
      }
    }
