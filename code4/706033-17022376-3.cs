    protected void OnPropertyChanged(string strPropertyName)
    {
        var handler =
           this.NonSerializablePropertyChangedHandlers[STR_PROPERTYCHANGEDEVENT]
               as EventHandler;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
