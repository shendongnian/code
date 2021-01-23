    private myClass _selectedBoxItem;
    public myClass SelectedBoxItem
    {
        get { return _selectedBoxItem; }
        set
        {
            _selectedBoxItem = value;
            OnPropertyChanged("SelectedBoxItem");
        }
    }
