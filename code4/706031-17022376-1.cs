    protected void OnPropertyChanged(string strPropertyName)
    {
        EventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
