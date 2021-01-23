    protected void OnPropertyChanged(string strPropertyName)
    {
        EventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            handler.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
