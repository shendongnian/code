    private ItemViewModel _selectedOne;
    
    public ItemViewModel SelectedOne 
    {
        get { return _selectedOne; }
        set 
        {
            if(_selectedOne != value)
            _selectedOne = value;
            RaisePropertyChanged("SelectedOne");
        }
    }
