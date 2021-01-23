    public MainViewModel()
    {
        _items = new ObservableCollection<ItemViewModel>();
    }
    public ObservableCollection<ItemViewModel> Items { 
        get {return _items;} 
        private set {_items = value;} 
    }
    private ObservableCollection<ItemViewModel> _items;
    
    private int _items_to_show_on_second_list = 10;
    public ObservableCollection<ItemViewModel> ItemsLimit { 
        get {return _items.Take(_items_to_show_on_second_list);} 
        private set {_items = value;} 
    }
