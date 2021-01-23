    private your_object_name _selectedItem;
    public your_object_name SelectedItem 
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            RaisePropertyChanged("SelectedItem");
        }
    }
