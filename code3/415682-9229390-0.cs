    _allItems.CollectionChanged += new NotifyCollectionChangedEventHandler(_allItems_CollectionChanged)
    protected void _allItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
         switch (e.Action)
             {
                 case NotifyCollectionChangedAction.Add:
                    //do stuff;
                     break;
                 case NotifyCollectionChangedAction.Remove:
                    //do stuff
                     break;
             }
    }
