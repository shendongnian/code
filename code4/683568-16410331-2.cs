	class CountedContext {
		int workersCount  = 0;
		Action<bool> notifier;	
		
		public CountedContext(Action<bool> notifier) { this.notifier = notifier; }
		
		public Task<TResult> Execte<TResult>(Func<Task<TResult>> func)
		{	
			lock(worksersCount) 
			{ 
				workersCount++; 
				
				if (workdersCount == 1)
					notifier(true);
			}
		
			var result = func();
			
			result.ContinueWith(_ => 
			{
				lock (worksersCount)
				{
					workersCount--;
					
					if (worksersCount == 0){
						notifier(false);
					}
				}
			});
			
			return result;
		}
	}
