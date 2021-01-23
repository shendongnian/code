    protected void RaisePropertyChanged([CallerMemberName] string propertyName=null)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
