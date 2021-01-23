    private readonly ObservableCollection<T> list;
    public ctor() {
        list = new ObservableCollection<T>();
        list.CollectionChanged += listChanged;
    }
    public ObservableCollection<T> List { get { return list; } }
    public void Clear() { list.Clear(); }
    private void listChanged(object sender, NotifyCollectionChangedEventArgs args) {
       // list changed
    }
