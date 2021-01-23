    using System.Reactive;
    using System.Reactive.Linq;
	private Task Run()
	{
		var fromWebObservable = from item in repo.GetItems.ToObservable(Scheduler.Default)
								select GetFromWeb(item.url);
		
		fromWebObservable
                        .Select(async x => await x)
			.Do(AddToDatabase)
			.ToTask();
		
	}
