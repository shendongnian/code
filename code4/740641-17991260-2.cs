    public static void doWork(IEnumerable<string> _source, int numThreads)
    {
        var _tokenSource = new CancellationTokenSource();
		List<Task> tasksToProcess = new List<Task>();
		foreach (var file in _source)
		{
			tasksToProcess.Add( Task.Factory.StartNew(() =>
                                  {
                                      Console.WriteLine("Processing " + file );
                                      //do file operation
                                      Thread.Sleep(5000);
                                      Console.WriteLine("Finished Processing " + file);
                                  },
                              _tokenSource.Token));
							  
			if(tasksToProcess.Count % numThreads == 0)
			{
				Console.WriteLine("Waiting for tasks");
				
        		Task.WaitAll(tasksToProcess.ToArray(), _tokenSource.Token);
				
        		Console.WriteLine("All tasks finished");   
				tasksToProcess.Clear();
			}
		}             
    }
    void Main()
    {
	    var fileList = Enumerable.Range(0, 100).Select (e => "file" + e.ToString());
        doWork(fileList, 4);
        Console.ReadLine();	
    }
