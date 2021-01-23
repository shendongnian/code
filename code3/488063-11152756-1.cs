    private static void Test(Object dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        NotifyCollectionChangedEventHandler handler = 
            (s, e) => SelectedItemsChanged(dependencyObject, e);
        var oldObservable = args.OldValue as ObservableCollection<object>;
        if (oldObservable != null)
        {
            oldObservable.CollectionChanged -= handler;
        }
        var newObservable = args.NewValue as ObservableCollection<object>;
        if (newObservable != null)
        {
            newObservable.CollectionChanged += handler;
        }
    }
