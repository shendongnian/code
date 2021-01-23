    // Gets or sets the CollectionViewSource
    public CollectionViewSource ViewSource { get; set; }
    // Gets or sets the ObservableCollection
    public ObservableCollection<T> Collection { get; set; }
    // Instantiates the objets.
    public ViewModel () {
        this.Collection = new ObservableCollection<T>();
        this.ViewSource = new CollectionViewSource();
        ViewSource.Source = this.Collection;
    }
