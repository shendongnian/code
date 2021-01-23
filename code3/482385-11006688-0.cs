	public IObservable<bool> ShowConfirmationDialogs(IEnumerable items)
	{
		var query =
			from item in items.OfType<SOMEBASETYPE>().ToObservable()
			from result in Service.ShowDialog(item =>
			{
				// do stuff with result that may impact next iteration of foreach
			})
			select new
			{
				Item = item,
				Result = result,
			};
	
		return query.TakeWhile(x => x.Result == true);
	}
