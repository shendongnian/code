    private static void Main(string[] args)
    {
    	var tasksIdDic = new ConcurrentDictionary<int?, string>();
    	Random rnd = new Random(DateTime.Now.Millisecond);
    	var tasks = new List<Task>();
    	
    	tasks.Add(Task.Run(() =>  
    	{
    		Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 5))).Wait();
    		tasksIdDic.TryAdd(Task.CurrentId, "First");
    
    		Console.WriteLine($"{tasksIdDic[Task.CurrentId]} completed.");
    	}));
    
    	tasks.Add(Task.Run(() =>
    	{
    		Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 5))).Wait();
    		tasksIdDic.TryAdd(Task.CurrentId, "Second");
    
    		Console.WriteLine($"{tasksIdDic[Task.CurrentId]} completed.");
    	}));
    
    	tasks.Add(Task.Run(() =>
    	{
    		Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 5))).Wait();
    		tasksIdDic.TryAdd(Task.CurrentId, "Third");
    
    		Console.WriteLine($"{tasksIdDic[Task.CurrentId]} completed.");
    	}));
    
       //do some work - there is no guarantee, but assuming you add the task names to the dictionary at the very beginning of each thread, the dictionary will be populated and be of benefit sometime soon after the start of the tasks.
       //Task.Delay(TimeSpan.FromSeconds(5)).Wait();
    
        //wait for all just so I see a console output
    	Task.WaitAll(tasks.ToArray());
    }
