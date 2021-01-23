    using System
    using System.Linq
    using System.Reactive.Concurrency
    using System.Reactive.Linq
    using System.Reactive.Threading.Tasks
    using System.Threading.Tasks
	void Main()
	{
		var tasks = new List<Task<bool>>
		{ 
			Task.Delay(2000).ContinueWith(x => false), 
			Task.Delay(0).ContinueWith(x => true), 
		};
		
		var observable = (from t in tasks
						let o = t.ToObservable() //Convert each task to a single observable
						select o)
                        //Convert the IEnumerable to a flat IObservable
                        .ToObservable().SelectMany(x => x);
						
		
		var foo = observable
					.SubscribeOn(Scheduler.Default) //Run the tasks on the threadpool
					.ToList()
                    .First();
		
		Console.WriteLine(foo);
	}
