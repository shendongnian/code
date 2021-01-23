    public bool MyBool 
    { 
       get { return _mybool; }
       set {
             _mybool = value;
             NotifyPropertyChanged("MyBool");
           }
    }
    public void NotifyPropertyChanged(string propertyName)
    {
       if (PropertyChanged != null)
           PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
    }
