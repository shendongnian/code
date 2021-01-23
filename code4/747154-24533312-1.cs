    private string _icon;
    public string Icon
    {
        get
        {
            return _icon;
        }
        set
        {
            if (value != _icon)
            {
                _icon = value;
                NotifyPropertyChanged("Icon");
            }
        }
    }
