    public PropertyChangedEventHandler PropertyChanged;
    
    ...
    
    private void OnPropertyChanged(string propertyName) {
      var saved = PropertyChanged;
      if (saved != null) { 
        var e = new PropertyChangedEventArgs(propertyName);
        saved(this, e);
      }
    }
