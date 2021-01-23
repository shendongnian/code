    using System.Reactive;
    using System.Reactive.Linq;
	private Task Run()
	{
		var fromWebObservable = from item in repo.GetItems.ToObservable(Scheduler.Default)
								select GetFromWeb(item.url);
		
		fromWebObservable
			.Do(AddToDatabase)
			.ToTask();
		
	}
