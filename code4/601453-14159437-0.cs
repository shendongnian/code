    private bool _isGridVisible;
    public bool IsGridVisible
    {
        get { return _isGridVisible; }
        set
        {
            if (_isGridVisible != value)
                return;
            _isGridVisible = value;
            OnPropertyChanged("IsGridVisible"); // This can sometimes be named RaisePropertyChanged
        }
    }
    private void OnClick(object sender, RoutedEventArgs e)
    {
        IsGridVisible = !IsGridVisible;
    }
