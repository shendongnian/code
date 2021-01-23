    ObservableCollection<string> newList = new ObservableCollection<string>();
    newList.Add("Item 1");
    newList.Add("Item 2");
    newList.Add("Item 3");
	
    Collection<string> newColl = new Collection<string>();
	newList.CollectionChanged += (sender, args) => 
			{
				foreach (var newItem in args.NewItems)
				{
					newColl.Add(newItem);
				}
				foreach (var removedItem in args.OldItems)
				{
					newColl.Remove(removedItem);
				}
			};
