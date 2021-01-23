    using Caliburn.Micro;
    
    private BindableCollection<KeyValuePair> _items;
    
    public BindableCollection<KeyValuePair> Items
    {
      get { return _items; }
    
      set
      {
        if (_items != value)
        {
          _items = value;
          NotifyOfPropertyChange(() => Items);
        }
      }
    }
