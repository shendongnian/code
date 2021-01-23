    private static void OnPointsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MyUserControl control = d as MyUserControl;
        // you have to replace ViewModelItemClass with the name of your class T
        // in ObservableCollection<T> from the property Data in your ViewModel
        var sourceCollection = e.NewValue as IEnumerable<ViewModelItemClass>;
        control._points.Clear();
        foreach (var item in sourceCollection)
        {
            control._points.Add(new DataPoint { Time = item.TimeUtc, Value = item.Value });
        }
    }
