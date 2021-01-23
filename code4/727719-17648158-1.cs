    private void SomeListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            // Some actions, in our case - start the animation
        }
    }
	
