    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        var handler = this.PropertyChanged;
        if (handler != null) {
            handler(this, new PropertyChangedEventArgs(propertyName);
        }
    }
