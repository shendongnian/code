    private string _selectedNotification;
    public string SelectedNotification
    {
        get { return _selectedNotification; }
        set
        {
            if (_selectedNotification != value)
            {
                _selectedNotification = value;
                RaisePropertyChanged("SelectedNotification");
            }
        }
    }
