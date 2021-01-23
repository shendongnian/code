    protected void OnPropertyChanged(string propertyName)
    {
       var handlers = PropertyChanged;
       if (handlers != null)
       {
          handlers(this, new PropertyChangedEventArgs(propertyName));
       }
    }
