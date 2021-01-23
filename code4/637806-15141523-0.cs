    collection.CollectionChanged += ContentCollectionChanged;
    [...]
    public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    	if (e.Action == NotifyCollectionChangedAction.Remove)
    	{
    		foreach(var file in e.OldItems)
    		{
    			//Removed file
    		}
    	}
    }
