    private Customer _selectedItem;
    public Customer SelectedItem
    {
        get {return _selectedItem;}
        set
        {
            if (!ReferenceEquals(_selectedItem, value))
            {
                _selectedItem.PropertyChanged -= OnCustomerPropertyChanged;
                _selectedItem = value;
                RaisePropertyChanged(()=>SeletedItem);
                _selectedItem.PropertyChanged += OnCustomerPropertyChanged;
            }
        }
    }
