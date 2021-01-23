    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler == null) return;
        handler (this, new PropertyChangedEventArgs(propertyName));
    }
