    ObservableCollection<T> myObservable = ...;
    myObservable.CollectionChanged += (sender, e) =>
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            // do stuff
        }
    };
