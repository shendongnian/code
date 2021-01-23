	var query = from var item in enumerable.Cast<ItemType>()
				where item.X == 1
				select item;
	var source = new ObservableCollection<object>();
	control.BindingSource = source;
	Task.Factory.StartNew(
		() =>
		{
			foreach(var item in query)
			{
				Application.Current.Dispatcher.BeginInvoke(
					new Action(() => source.Add(item)));
			}
		},
		TaskCreationOptions.LongRunning);
