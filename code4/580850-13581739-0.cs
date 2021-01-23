		public void GetItemsAsync(Action<Item[]> handleResult)
		{
			int Id = 11;
			Task<Item[]> task = Task.Factory.StartNew(() => CreateItems(Id)); // May take a second or two
			task.ContinueWith(t => handleResult(t.Result), TaskScheduler.FromCurrentSynchronizationContext());
		}
