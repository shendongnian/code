    public static WebService() 
    {
      new Thread(WorkerThread).Start();
      WorkQueue = new Queue<WorkItem>();
    }
    
    public static void WorkerThread() 
    {
      while(true)
      {
        if(WorkQueue.Any()) 
        {
          WorkQueue.Dequeue().DoWork();
        }
        else
        {
          Thread.Sleep(100);
        }
      }
    }
    
    public static Queue<WorkItem> WorkQueue { get; set; }
    
    [System.Web.Services.WebMethod]
    public List<Foo> SampleWebMethod(string id)
    {
      WorkQueue.Queue(newWorkItem());
    }
