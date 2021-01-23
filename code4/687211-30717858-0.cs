	public SynchronizedObservableCollection()
	{
		_context = SynchronizationContext.Current;
	}
	private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		var collectionChanged = CollectionChanged;
		if (collectionChanged == null)
		{
			return;
		}
	 
		using (BlockReentrancy())
		{
			_context.Send(state => collectionChanged(this, e), null);
		}
	}
	
	public bool Contains(T item)
	{
		_itemsLock.EnterReadLock();
	 
		try
		{
			return _items.Contains(item);
		}
		finally
		{
			_itemsLock.ExitReadLock();
		}
	}
	public void Add(T item)
	{
		_itemsLock.EnterWriteLock();
	 
		var index = _items.Count;
		
		try
		{
			CheckIsReadOnly();
			CheckReentrancy();
	 
			_items.Insert(index, item);
		}
		finally
		{
			_itemsLock.ExitWriteLock();
		}
	 
		OnPropertyChanged("Count");
		OnPropertyChanged("Item[]");
		OnCollectionChanged(NotifyCollectionChangedAction.Add, item, index);
	}
