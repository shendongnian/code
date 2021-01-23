    messageList.CollectionChanged += messageList_CollectionChanged;
    
    private void messageList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
    	filteredView.Refresh(); 
    }
