    // Set the ItemsSource
    SampleListBox.ItemsSource = SomeListBoxCollection;
    // Set handler on the collection
    SomeListBoxCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(SomeListBoxCollection_CollectionChanged);
    private void SomeListBoxCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            // Some actions, in our case - start the animation
        }
    }
	
