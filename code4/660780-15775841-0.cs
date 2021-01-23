    public void Add(T artist)
    {
        _list.AddLast(artist);
         if (CollectionChanged != null) {
    	     CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Item));
        }
    }
