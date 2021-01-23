    public static async Task ForEachWithDelay<T>(this ICollection<T> items, Func<T, Task> action, double interval)
    {
    	using (var timer = new System.Timers.Timer(interval))
    	{
    		var task = new Task(() => { });
    		int remaining = items.Count;
    		var queue = new ConcurrentQueue<T>(items);
    
    		timer.Elapsed += async (sender, args) =>
    		{
    			T item;
    			if (queue.TryDequeue(out item))
    			{
    				try
    				{
    					await action(item);
    				}
    				finally
    				{
    					// Complete task.
    					remaining -= 1;
    
    					if (remaining == 0)
    					{
    						// No more items to process. Complete task.
    						task.Start();
    					}
    				}
    			}
    		};
    
    		timer.Start();
    
    		await task;
    	}
    }
