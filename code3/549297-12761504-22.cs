    public int SelectedIndexA
    {
        get { return _selectedIndexA; }
        set
        {
            _selectedIndexA = value;
            _selectedIndexB = -1;
            OnPropertyChanged("SelectedIndexB");
        }
    }
    public int SelectedIndexB
    {
        get { return _selectedIndexB; }
        set
        {
            _selectedIndexB = value;
            _selectedIndexA = -1;
            OnPropertyChanged("SelectedIndexA");
        }
    }
