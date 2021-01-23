    public ObservableCollection<Thing> Items{
    get { return _items; }
    set{ _items = value; RaisePropertyChanged("Items");  // Do additional processing here 
    }
    }
