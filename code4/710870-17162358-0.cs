      public bool IsDirty { get; private set; }
      protected void RaisePropertyChanged(string propertyName)
      {
         var handler = this.PropertyChanged;
         if (handler != null)
         {
            handler(this, new PropertyChangedEventArgs(propertyName));
            this.OnPropertyChanged(propertyName);
         }
      }
      protected void OnPropertyChanged(string propertyName)
      {
         IsDirty = true;
      }
      public void Save()
      {
         IsDirty = false;
      }
