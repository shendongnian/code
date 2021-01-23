      public StringBuilder Data
      {
         get { return _data; }
         set
         {
            _data = null;
            OnPropertyChanged("Data");
            _data = value;
            OnPropertyChanged("Data");
         }
      }
