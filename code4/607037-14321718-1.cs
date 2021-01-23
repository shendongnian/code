    SomeObject.PropertyChanged += SomeObject_PropertyChanged;
    
    ...
    
    void SomeObject_PropertyChanged(object src, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "PropertyA" || e.PropertyName == "PropertyB")
        {
            RaisePropertyChanged("SomeObject");
        }
    }
