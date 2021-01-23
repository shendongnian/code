    public int SelectedTabIndex
    {
        get { return _selectedTabIndex;}
        set
        {
            if (_selectedTabIndex != value)
            {
                _selectedTabIndex = value;
                RaisePropertyChanged("SelectedTabIndex");
                RaisePropertyChanged("SelectedPanel");
            }
        }
    }
    public UserControl SelectedPanel
    {
        get { return tabControls[SelectedTabIndex]; }
    }
