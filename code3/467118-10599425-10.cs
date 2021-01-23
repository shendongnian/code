    class Column : INotifyPropertyChanged {
    
      Boolean isActive;
    
      public Boolean IsActive {
        get { return this.isActive; }
        set {
          if (this.isActive == value)
            return;
          this.isActive = value;
          OnPropertyChanged("IsActive");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected void OnPropertyChanged(String propertyName) {
        var handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    
    }
