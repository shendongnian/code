    private Customer _selectedItem;
    public Customer SelectedItem
    {
        get {return _selectedItem;}
        set
        {
            if (!ReferenceEquals(_selectedItem, value))
            {
                if (!ReferenceEquals(null, _selectedItem))
                    _selectedItem.PropertyChanged -= OnCustomerPropertyChanged;
                _selectedItem = value;
                RaisePropertyChanged(()=>SelectedItem);
                if (!ReferenceEquals(null, _selectedItem))
                    _selectedItem.PropertyChanged += OnCustomerPropertyChanged;
            }
        }
    }
