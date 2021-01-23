    BlockingCollection<Item> workList;
    CancellationTokenSource cts;
    int itemcount
    
    public void Run()
    {
      int num_workers = 4;
    
      //create worklist, filled with initial work
      worklist = new BlockingCollection<Item>(
        new ConcurrentQueue<Item>(GetInitialWork()));
    
      cts = new CancellationTokenSource();
      itemcount = worklist.Count();
    
      for( int i = 0; i < num_workers; i++)
        Task.Factory.StartNew( RunWorker );
    }
    
    IEnumberable<Item> GetInitialWork() { ... }
    
    public void RunWorker() {
      try  {
        do {
          Item i = worklist.Take( cts.Token );
          //blocks until item available or cancelled
              Process(i);
          //exit loop if no more items left
        } while (Interlocked.Decrement( ref itemcount) > 0);
      } finally {
          if( ! cts.IsCancellationRequested )
            cts.Cancel();
        }
      }
    }
    public void AddWork( Item item) {
      Interlocked.Increment( ref itemcount );
      worklist.Add(item);
    }
    
    public void Process( Item i ) 
    {
      //Do what you want to the work item here.
    }
    
