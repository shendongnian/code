    public Item SelectedItem
    {
        get { return _selectedItem; }
        set 
        {
            if(value != _selectedItem)
            {
                _selectedItem= value; 
                OnPropertyChanged("SelectedItem");
            }
        }
    }
