    public ctor() {
        List = new ObservableCollection<T>();
        List.CollectionChanged += OnListChanged;
    }
    public ObservableCollection<T> List { get; }
    public void Clear()
    {
        List.Clear();
    }
    private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
    {
       // react to list changed
    }
