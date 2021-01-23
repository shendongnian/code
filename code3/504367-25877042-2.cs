    public static void RunWithMaxDegreeOfConcurrency<T>(
         int maxDegreeOfConcurrency, IEnumerable<T> collection, Func<T, Task> taskFactory)
    {
    	var activeTasks = new List<Task>(maxDegreeOfConcurrency);
    	foreach (var task in collection.Select(taskFactory))
    	{
    		activeTasks.Add(task);
    		if (activeTasks.Count == maxDegreeOfConcurrency)
    		{
    			Task.WaitAny(activeTasks.ToArray());
    			activeTasks.RemoveAll(t => t.IsCompleted);
    		}
    	}
    	Task.WaitAll(activeTasks.ToArray());
    }
