    private BitmapImage _display;
    public BitmapImage Display
    {
        get { return _display; }
        set
        {
            _display = value;
            RaisePropertyChanged("Display");
        }
    }
