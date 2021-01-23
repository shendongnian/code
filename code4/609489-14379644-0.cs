    private ObsersvableCollection<Type> _MyCollection = new ObservableCollection<Type>();
    _MyCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(_MyCollection_CollectionChanged);
    protected void _MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch(e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                //use e.NewItems to get items added.     
            break;
            case NotifyCollectionChangedAction.Remove:
                //use e.OldItems to get items removed.
            break;
        }
    }
