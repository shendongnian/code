    public void search()
    {
       Task.Factory.StartNew(() =>
       {
			
			var filtered = source.AsParallel()
                                       .WithDegreeOfParallelism(5)
                                       .Where(file =>
			{
				try
				{
					//Some filter function...
				}
				catch(Exception)
				{
					return false;
				}
			});
			return filtered.ToList();
		}).ContinueWith
       	(t =>
       	{
			foreach(var result in t.Result)
			{
				MyListBox.Add(result);
			}
           	OnFinishSearchEvent();
       	}
	   	, TaskScheduler.FromCurrentSynchronizationContext() //to ContinueWith (update UI) from UI thread
       	);
			
			
    }
